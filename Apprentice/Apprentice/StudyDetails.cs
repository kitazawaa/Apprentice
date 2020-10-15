using ClassLibrary;
using DatabaseManager;
using log4net;
using System;
using System.Windows.Forms;

namespace Apprentice
{
    public partial class StudyDetails : Form
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private WorkItem _item;
        private WorkItemDetails _itemDetails;

        public StudyDetails(WorkItem item, WorkItemDetails itemDetails)
        {
            InitializeComponent();

            this._item = item;
            this._itemDetails = itemDetails;
        }


        #region 詳細表示
        /// <summary>
        /// 詳細表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudyDetailsLoad(object sender, EventArgs e)
        {
            //オーダー番号
            orderNumberTextBox.Text = _item.OrderNumber.ToString();
            //検査状況
            studyStatusTextBox.Text = _item.StudyStatus;
            //予約日
            scheduledOnTextBox.Text = _item.ScheduledOn.ToLongDateString();
            //検査日
            studiedAtTextBox.Text = _itemDetails.StudiedAt.ToLongDateString();
            //患者ID
            patientIdTextBox.Text = _item.PatientId.ToString();
            //氏名
            patientKanjiNameTextBox.Text = _item.PatientKanjiName;
            //シメイ
            patientKanaNameTextBox.Text = _item.PatientKanaName;
            //生年月日
            patientBirthDateTimePicker.Text = _itemDetails.PatientBirthDate.ToLongDateString();
            //性別
            patientGenderComboBox.Text = _itemDetails.PatientGender;
            //検査種
            studyTypeNameTextBox.Text = _item.StudyTypeName;
            //撮影項目
            shotItemTextBox.Text = _item.ShotItemName;
            //コメント
            commentTextBox.Text = _item.Comment;

            if (_item.StudyStatus == "受付済")
            {
                DbManager.InsertOneStudyTable(_item, _itemDetails);
            }
        }

        #endregion

        #region 更新
        /// <summary>
        /// 患者属性情報及びコメントの内容を更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButtonClick(object sender, EventArgs e)
        {
            if (patientKanjiNameTextBox.Text == "")
            {
                MessageBox.Show("氏名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else if (patientKanaNameTextBox.Text == "")
            {
                MessageBox.Show("シメイを入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_item.PatientKanjiName != patientKanjiNameTextBox.Text || _item.PatientKanaName != patientKanaNameTextBox.Text ||
                    _itemDetails.PatientBirthDate != patientBirthDateTimePicker.Value || _itemDetails.PatientGender != patientGenderComboBox.Text)
                {
                    //漢字氏名の更新
                    _item.PatientKanjiName = patientKanjiNameTextBox.Text;
                    //カナ氏名の更新
                    _item.PatientKanaName = patientKanaNameTextBox.Text;
                    //生年月日の更新
                    _itemDetails.PatientBirthDate = DateTime.Parse(patientBirthDateTimePicker.Text);
                    //性別の更新
                    _itemDetails.PatientGender = patientGenderComboBox.Text;
                    //検査テーブルの更新日時の更新
                    _item.StudyUpdatedAt = DateTime.Now;

                    logger.Info("オーダー番号" + _item.OrderNumber + "の患者情報を更新しました。");
                }

                if (_item.Comment != commentTextBox.Text)
                {
                    //コメントの更新
                    _item.Comment = commentTextBox.Text;

                    logger.Info("オーダー番号" + _item.OrderNumber + "のコメントを更新しました。");
                }
            }
        }

        #endregion

        #region 受付済へ遷移
        /// <summary>
        /// 受付済へ変更ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeIntoAcceptedButtonClick(object sender, EventArgs e)
        {
            if (studyStatusTextBox.Text != "予約済")
            {
                //検査状況が予約済以外のときは何も起こらない
            }
            else
            {
                DbManager.ChangeIntoAccepted(_item);

                DbManager.InsertOneStudyTable(_item, _itemDetails);

                studyStatusTextBox.Text = "受付済";

                logger.Info("オーダー番号" + _item.OrderNumber + "の検査状況を受付済に変更しました。");
            }
        }

        #endregion

        #region 撮影済へ遷移
        /// <summary>
        /// 撮影済変更ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeIntoPerformedButtonClick(object sender, EventArgs e)
        {
            if (studyStatusTextBox.Text != "受付済")
            {
                //検査状況が受付済以外のときは何も起こらない
            }
            else
            {
                DbManager.ChangeIntoPerformed(_item);

                DbManager.DeleteOneStudyTable(_item);

                studyStatusTextBox.Text = "撮影済";

                logger.Info("オーダー番号" + _item.OrderNumber + "の検査状況を撮影済に変更しました。");
            }
        }

        #endregion

        #region 検査状況を戻す
        /// <summary>
        /// 検査状況を一つ前に戻すボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoStudyStatusButtonClick(object sender, EventArgs e)
        {
            if (studyStatusTextBox.Text == "撮影済")
            {
                //検査状況が撮影済の時は受付済に遷移する
                DbManager.ChangeIntoAccepted(_item);

                DbManager.InsertOneStudyTable(_item, _itemDetails);

                studyStatusTextBox.Text = "受付済";

                logger.Info("オーダー番号 " + _item.OrderNumber + "の検査状況を受付済に戻しました。");
            }
            else if (studyStatusTextBox.Text == "受付済")
            {
                //検査状況が受付済の時は予約済に遷移する
                DbManager.ChangeIntoReserved(_item);

                DbManager.DeleteOneStudyTable(_item);

                studyStatusTextBox.Text = "予約済";

                logger.Info("オーダー番号 " + _item.OrderNumber + "の検査状況を予約済に戻しました。");
            }
            else
            {
                //検査状況が他のステータスの時は何も起こらない
            }
        }

        #endregion

        #region 一覧画面に戻る
        private void GoBackLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DbManager.DeleteOneStudyTable(_item);

            this.Close();
        }

        #endregion


    }
}
