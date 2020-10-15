using Apprentice.Properties;
using ClassLibrary;
using DatabaseManager;
using Entity;
using log4net;
using System;
using System.Windows.Forms;

namespace Apprentice
{
    public partial class StudyList : Form
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Users _user;

        #region 初期状態
        public StudyList(Users user)
        {
            this._user = user;

            InitializeComponent();

            //検索条件の検査日付の初期状態
            var today = DateTime.Today.Date;
            searchFromStudyDateTimePicker.Value = today;
            searchToStudyDateTimePicker.Value = today;

            //自動更新設定の初期状態を表示
            validRadioButton.Checked = Settings.Default.AutoUpdateValid;
            invalidRadioButton.Checked = Settings.Default.AutoUpdateInvalid;
            updateIntervalNumericUpDown.Text = Settings.Default.UpdateInterval.ToString();

            updateTimer.Interval = Settings.Default.UpdateInterval * 1000;

            if (validRadioButton.Checked)
            {
                //自動更新間隔を設定可能にする
                updateIntervalNumericUpDown.Enabled = true;
                //タイマースタート
                updateTimer.Start();
            }
            else
            {
                //自動更新間隔を設定不可能にする
                updateIntervalNumericUpDown.Enabled = false;
                //タイマーストップ
                updateTimer.Stop();
            }
        }

        public StudyList()
        {
            InitializeComponent();
        }

        #endregion

        #region 自動更新設定

        /// <summary>
        /// 自動更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimerTick(object sender, EventArgs e)
        {
            DisplayStudylist();

            logger.Info("一覧表示を自動更新しました。");
        }

        //自動更新の有効化・無効化
        private void ValidRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (validRadioButton.Checked)
            {
                //自動更新間隔を設定可能にする
                updateIntervalNumericUpDown.Enabled = true;
                //タイマースタート
                updateTimer.Start();

                logger.Info("自動更新を有効にしました。");
            }
            else
            {
                //自動更新間隔を設定不可能にする
                updateIntervalNumericUpDown.Enabled = false;
                //タイマーストップ
                updateTimer.Stop();

                logger.Info("自動更新を無効にしました。");
            }

            //設定を保持
            Settings.Default.AutoUpdateValid = validRadioButton.Checked;
            Settings.Default.AutoUpdateInvalid = invalidRadioButton.Checked;
            Settings.Default.Save();
        }

        private void InvalidRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            //設定を保持
            Settings.Default.AutoUpdateValid = validRadioButton.Checked;
            Settings.Default.AutoUpdateInvalid = invalidRadioButton.Checked;
            Settings.Default.Save();
        }

        //自動更新間隔の変更
        private void UpdateIntervalNumericUpDownValueChanged(object sender, EventArgs e)
        {
            updateTimer.Stop();

            //設定を保持
            Settings.Default.UpdateInterval = (int)updateIntervalNumericUpDown.Value;
            Settings.Default.Save();

            updateTimer.Start();

            logger.Info("自動更新間隔を変更しました。");
        }

        #endregion

        #region 一覧表示

        /// <summary>
        /// 一覧表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudyListLoad(object sender, EventArgs e)
        {
            //検査を表示
            DisplayStudylist();

            //タイマースタート
            if (validRadioButton.Checked)
            {
                updateTimer.Start();
            }
        }

        #endregion

        #region 手動更新

        /// <summary>
        /// 更新ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButtonClick(object sender, EventArgs e)
        {
            DisplayStudylist();

            logger.Info("一覧表示を手動更新しました。");
        }

        #endregion

        #region 検査日付の設定       

        /// <summary>
        /// 検索の開始日が終了日よりも前の日か同日になるよう設定
        /// </summary>
        private void SearchFromStudyDateDateTimePickerValueChanged(object sender, EventArgs e)
        {       
            var from = searchFromStudyDateTimePicker.Value;
            var to = searchToStudyDateTimePicker.Value;

            if (from > to)
            {
                searchFromStudyDateTimePicker.Value = to;
            }
        }
        /// <summary>
        /// 検索の終了日が開始日よりも後の日か同日になるよう設定
        /// </summary>
        private void SearchToStudyDateDateTimePickerValueChanged(object sender, EventArgs e)
        {
            var from = searchFromStudyDateTimePicker.Value;
            var to = searchToStudyDateTimePicker.Value;

            if (from > to)
            {
                searchToStudyDateTimePicker.Value = from;
            }
        }

        #endregion      

        #region 検索
        /// <summary>
        /// 検索結果表示
        /// </summary>
        private void DisplayStudylist()
        {
            DateTime fromStudyDate = searchFromStudyDateTimePicker.Value.Date;
            DateTime toStudyDate = searchToStudyDateTimePicker.Value.Date;

            string patientId = searchPatientIdTextBox.Text;

            string studyStatus = searchStudyStatusComboBox.Text;

            //検査日検索
            if (string.IsNullOrWhiteSpace(patientId) && string.IsNullOrWhiteSpace(studyStatus))
            {
                studyviewBindingSource.DataSource = DbManager.SearchStudyListByStudyDate(fromStudyDate, toStudyDate);

                logger.Info("検査日で絞込しました。");
            }
            //患者ID検索
            else if (searchFromStudyDateTimePicker.Checked == false && searchToStudyDateTimePicker.Checked == false && string.IsNullOrWhiteSpace(studyStatus))
            {
                studyviewBindingSource.DataSource = DbManager.SearchStudyListByPatientId(patientId);

                logger.Info("患者IDで絞込しました。");

            }
            //検査状況検索
            else if (searchFromStudyDateTimePicker.Checked == false && searchToStudyDateTimePicker.Checked == false && string.IsNullOrWhiteSpace(patientId))
            {
                studyviewBindingSource.DataSource = DbManager.SearchStudyListByStudyStatus(studyStatus);

                logger.Info("検査状況で絞込しました。");
            }
            //検査日&検査状況検索
            else if (string.IsNullOrWhiteSpace(patientId))
            {
                studyviewBindingSource.DataSource = DbManager.SearchStudyListByStudyDateAndStudyStatus(fromStudyDate, toStudyDate, studyStatus);

                logger.Info("検査日と検査状況で絞込しました。");
            }
            //検査日＆患者ID検索
            else if (string.IsNullOrWhiteSpace(studyStatus))
            {
                studyviewBindingSource.DataSource = DbManager.SearchStudyListByStudyDateAndPatientId(fromStudyDate, toStudyDate, patientId);

                logger.Info("検査日と患者IDで絞込しました。");
            }
            //検査状況＆患者ID検索
            else if (searchFromStudyDateTimePicker.Checked == false && searchToStudyDateTimePicker.Checked == false)
            {
                studyviewBindingSource.DataSource = DbManager.SearchStudyListByStudyStatusAndPatientId(studyStatus, patientId);

                logger.Info("検査状況と患者IDで絞込しました。");
            }
            //検査日＆検査状況＆患者ID検索
            else
            {
                studyviewBindingSource.DataSource = DbManager.SearchStudyListByStudyDateAndStudyStatusAndPatientId(fromStudyDate, toStudyDate, patientId, studyStatus);

                logger.Info("検査日と検査状況と患者IDで絞込しました。");
            }
        }

        #endregion

        #region 検査詳細画面に遷移
        /// <summary>
        /// 検査詳細ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudyDetailsButtonClick(object sender, EventArgs e)
        {
            if (studyListDataGridView.SelectedRows.Count != 0)
            {
                WorkItem item = studyListDataGridView.CurrentRow.DataBoundItem as WorkItem;

                WorkItemDetails itemDetails = DbManager.SearchItemDetails(item.PatientId);            
                
                StudyDetails studydetail = new StudyDetails(item, itemDetails);
                studydetail.ShowDialog();
            }
        }
        #endregion

        #region 検査保留
        /// <summary>
        /// 保留ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HoldButtonClick(object sender, EventArgs e)
        {
            if (studyListDataGridView.SelectedRows.Count != 0)
            {
                if (validRadioButton.Checked)
                {
                    updateTimer.Stop();
                }

                DialogResult answer = MessageBox.Show("実行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (answer == DialogResult.Yes)
                {
                    WorkItem item = studyListDataGridView.CurrentRow.DataBoundItem as WorkItem;
                    DbManager.HoldStudy(item.OrderNumber);

                    logger.Info("オーダー番号 " + item.OrderNumber + "の検査を保留にしました。");

                    DisplayStudylist();
                }

                if (validRadioButton.Checked)
                {
                    updateTimer.Start();
                }
            }
        }

        #endregion

        #region 新規ユーザー登録画面に遷移
        /// <summary>
        /// 新規ユーザー登録ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserRegistrationLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserRegistration userreg = new UserRegistration();
            userreg.ShowDialog();
        }
        #endregion

        #region ユーザー情報変更画面に遷移
        /// <summary>
        /// ユーザー情報変更ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoChangeLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserSetting usersetting = new UserSetting(_user);
            usersetting.ShowDialog();
        }
        #endregion

        #region ログアウト
        /// <summary>
        /// ログアウトボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutButtonClick(object sender, EventArgs e)
        {
            this.Close();

            logger.Info(_user.UserName + "さんがログアウトしました。");
        }


        #endregion

        private void HeldStudyListButton_Click(object sender, EventArgs e)
        {
            HeldStudyList heldstudy = new HeldStudyList();
            heldstudy.ShowDialog();
        }
    }
}
