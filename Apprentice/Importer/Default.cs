using ClassLibrary;
using DatabaseManager;
using Entity;
using Importer.Properties;
using log4net;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Importer
{
    public partial class Default : Form
    {

        ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Default()
        {
            InitializeComponent();
        }

        private void DefaultLoad(object sender, EventArgs e)
        {
            importTimer.Interval = Settings.Default.RetryInterval * 1000;
            importTimer.Start();
        }

        #region 自動取り込み
        /// <summary>
        /// 自動取り込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportTimerTick(object sender, EventArgs e)
        {
            importTimer.Stop();
            statusLabel.Text = "ファイルを取り込んでいます...";

            try
            {
                Import();
            }
            catch (DirectoryNotFoundException ex)
            {
                logger.Warn(ex.Message);
            }

            statusLabel.Text = "";
            importTimer.Start();
        }

        #endregion

        #region CSVファイル取り込み処理

        // 監視フォルダにCSVファイルがあって、項目が書かれている前提でCSVファイルを読めないパターンは以下の4つ
        // 1.フォーマットが不正
        // 2.項目が抜けている
        // 3.コードと名称が対になっていない
        // 4.Validation Error

        //監視フォルダのパス
        private string monitoredFolderPath;
        //エラーフォルダのパス
        private string errorFolderPath;
        //処理済みフォルダのパス
        private string processedFolderPath;
        //ファイル形式
        private string fileFormat;      

        /// <summary>
        /// CSVファイル取り込み処理
        /// </summary>
        public void Import()
        {
            //フォルダの設定
            monitoredFolderPath = Settings.Default.MonitoredFolder;
            errorFolderPath = Settings.Default.ErrorFolder;
            processedFolderPath = Settings.Default.ProcessedFolder;

            //ファイル形式の設定
            fileFormat = Settings.Default.FileFormat;

            //監視対象フォルダ内のCSVファイルを取得
            IEnumerable<string> Monitoredfiles = Directory.EnumerateFiles(monitoredFolderPath, fileFormat, System.IO.SearchOption.AllDirectories);

            try
            {
                foreach (string file in Monitoredfiles)
                {
                    using (TextFieldParser parser = new TextFieldParser(file, Encoding.GetEncoding(932)))
                    {
                        //ヘッダ行読み飛ばし
                        parser.ReadLine();
                        //行数の初期値(2行目から取り込み)
                        int rowCount = 2;

                        //1.フォーマットが不正の場合の対策
                        parser.TextFieldType = FieldType.Delimited;
                        //区切り文字を「,」に設定
                        parser.SetDelimiters(",");

                        //読み込むべき行がまだ残っているかどうか判定
                        while (!parser.EndOfData)
                        {
                            try
                            {
                                //現在行のフィールドを配列に入れる
                                string[] row = parser.ReadFields();
                                //CSV項目クラスに入れる
                                CsvItem items = this.ReadCsvItem(row);
                                //患者情報を登録
                                string patientId = DbManager.ImportPatientInfo(RegisterPatient(items));
                                //検査情報を登録
                                DbManager.ImportStudyInfo(patientId, RegisterStudy(items));
                                //読み込んだファイルは処理済みフォルダへ移動
                                this.TransferToProcessedFolder(file);
                            }
                            catch (Exception e)
                            {
                                int retryLeft = 0;

                                //指定された回数だけ再処理
                                if (retryLeft < Settings.Default.RetryCount)
                                {
                                    retryLeft++;

                                    parser.Close();

                                    Import();
                                }
                                else
                                {
                                    //読み込めないファイルはエラーフォルダへ移動
                                    this.TransferToErrorFolder(file);

                                    logger.Error(e.Message);
                                    logger.Error(file);
                                    logger.Error(rowCount);
                                }
                            }

                            rowCount++;
                        }

                    }

                }
            }
            catch (DirectoryNotFoundException ex)
            {
                logger.Error(ex.Message);
                logger.Error(monitoredFolderPath);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        #endregion

        #region データベース登録
        /// <summary>
        /// 患者テーブルに患者情報を登録
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Patients RegisterPatient(CsvItem item)
        {
            Patients patient = new Patients();

            patient.PatientId = item.PatientId;
            patient.PatientKanjiName = item.PatientKanjiName;
            patient.PatientKanaName = item.PatientKanaName;
            patient.PatientBirthDate = DateTime.Parse(item.PatientBirthDate);
            patient.PatientGender = item.PatientGender;

            return patient;
        }

        /// <summary>
        /// 検査テーブルに検査情報を登録
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ValidatedStudyItems RegisterStudy(CsvItem item)
        {
            ValidatedStudyItems studyItems = new ValidatedStudyItems();

            studyItems.OrderNumber = int.Parse(item.OrderNumber);
            studyItems.ScheduledOn = DateTime.Parse(item.ScheduledOn);
            studyItems.ProcessingDivision = int.Parse(item.ProcessingDivision);
            studyItems.StudyTypeCode = item.StudyTypeCode;
            studyItems.StudyTypeName = item.StudyTypeName;
            studyItems.ShotItemSet = item.ShotItemSet;

            return studyItems;
        }

        #endregion

        #region CSVファイル取り込み条件
        /// <summary>
        /// CSVファイル読み込み処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="file"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        private CsvItem ReadCsvItem(string[] row)
        {
            //2.項目が抜けている場合の対策           
            CsvItem item = new CsvItem();

            item.OrderNumber = row[0];
            item.ScheduledOn = row[1];
            item.ProcessingDivision = row[2];
            item.StudyTypeCode = row[3];
            item.StudyTypeName = row[4];
            item.PatientId = row[5];
            item.PatientKanjiName = row[6];
            item.PatientKanaName = row[7];
            item.PatientBirthDate = row[8];
            item.PatientGender = row[9];

            //3.撮影項目コードと撮影項目名称が対になっていない場合の対策
            //撮影項目コードと撮影項目名称をセットにする
            item.ShotItemSet = this.ShotItemSet(row);

            //4.Validation Errorの対策
            ValidationError validation = new ValidationError();
            validation.ValidateItems(item);

            return item;
        }

        /// <summary>
        /// 撮影項目Listを作成
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private List<ShotItemSet> ShotItemSet(string[] row)
        {
            List<ShotItemSet> shotItems = new List<ShotItemSet>();

            //項目抜けがなければ11番目以降は撮影項目コードと撮影項目名称がセットで続くので
            //for文でListに入れていく
            for (int i = 10; i < row.Length; i += 2)
            {
                ShotItemSet itemSet = new ShotItemSet
                {
                    ShotItemCode = row[i],
                    ShotItemName = row[i + 1]
                };

                shotItems.Add(itemSet);
            }

            return shotItems;
        }

        #endregion

        #region ファイル移動

        /// <summary>
        /// エラーフォルダへ移動
        /// </summary>
        /// <param name="filePath"></param>
        private void TransferToErrorFolder(string filePath)
        {
            try
            {

                //エラーファイルの絶対パスを取得
                string errorFileName = Path.GetFileName(filePath);
                string errorFilePath = Path.Combine(errorFolderPath, errorFileName);

                //ファイルをエラーフォルダに移動
                File.Move(filePath, errorFilePath);

                logger.Warn(errorFileName + "は" + errorFolderPath + "に移動しました。");
            }
            catch (DirectoryNotFoundException ex)
            {
                logger.Error(ex.Message);
                logger.Error(errorFolderPath);
            }
            catch (Exception ex)
            {
                logger.Warn(ex.Message);
            }

        }

        /// <summary>
        /// 処理済みフォルダへ移動
        /// </summary>
        /// <param name="filePath"></param>
        private void TransferToProcessedFolder(string filePath)
        {
            try
            {
                //処理済みファイルの絶対パスを取得
                string processedFolderName = Path.GetFileName(filePath);
                string processedFilePath = Path.Combine(processedFolderPath, processedFolderName);

                //ファイルを処理済みフォルダに移動
                File.Move(filePath, processedFilePath);
            }
            catch (DirectoryNotFoundException ex)
            {
                logger.Error(ex.Message);
                logger.Error(monitoredFolderPath);
            }
            catch (Exception ex)
            {
                logger.Warn(ex.Message);
            }

        }

        #endregion

        #region アプリケーション終了
        /// <summary>
        /// フォームが閉じられたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Default_FormClosing(object sender, FormClosingEventArgs e)
        {
            importTimer.Stop();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("ウィンドウを閉じますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    logger.Info("検査依頼データ取り込みプログラムが終了しました");
                }
                else
                {
                    e.Cancel = true;
                    importTimer.Start();
                    logger.Info("タイマーがスタートしました");
                }
            }
            else
            {
                logger.Info("検査依頼データ取り込みプログラムが終了しました");
            }
        }




        #endregion


    }
}
