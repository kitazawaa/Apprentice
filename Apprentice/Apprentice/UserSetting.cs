using ClassLibrary;
using DatabaseManager;
using Entity;
using log4net;
using System;
using System.Windows.Forms;

namespace Apprentice
{
    public partial class UserSetting : Form
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Users _user;

        public UserSetting(Users user)
        {
            InitializeComponent();

            this._user = user;
        }

        #region 初期状態
        /// <summary>
        /// 現在のユーザー情報を表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserSettingLoad(object sender, EventArgs e)
        {
            userIdTextBox.Text = _user.UserId;
            userNameTextBox.Text = _user.UserName;
            startEffectiveDateTimePicker.Text = _user.StartedOn.ToString();
            endingEffectiveDateTimePicker.Text = _user.ExpiredOn.ToString();

            startEffectiveDateTimePicker.Value = DateTime.Today;
            endingEffectiveDateTimePicker.Value = DateTime.Today.AddYears(1);
        }

        #endregion

        #region 有効期限の設定

        /// <summary>
        /// 有効期限の開始日が終了日よりも前の日か同日になるよう設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartEffectiveDateTimePickerValueChanged(object sender, EventArgs e)
        {
            var start = startEffectiveDateTimePicker.Value;
            var end = endingEffectiveDateTimePicker.Value;

            if (start > end)
            {
                startEffectiveDateTimePicker.Value = end;
            }
        }

        /// <summary>
        /// 有効期限の終了日が開始日よりも後の日か同日になるよう設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndingEffectiveDateTimePickerValueChanged(object sender, EventArgs e)
        {
            var start = startEffectiveDateTimePicker.Value;
            var end = endingEffectiveDateTimePicker.Value;

            if (start > end)
            {
                endingEffectiveDateTimePicker.Value = start;
            }
        }
        
        #endregion

        #region ユーザー情報変更
        /// <summary>
        /// ユーザー情報変更ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeUserInfoButtonClick(object sender, EventArgs e)
        {
            if (userNameTextBox.TextLength < 1)
            {
                MessageBox.Show("ユーザー名は1文字以上、32文字以内で入力してください。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("入力されたユーザー名が文字数制限を満たしていない。");
            }
            else if (passwordTextBox.TextLength < 8)
            {
                MessageBox.Show("パスワードは8文字以上、32文字以内で入力してください。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("入力されたパスワードが文字数制限を満たしていない。");
            }
            else if (passwordTextBox.Text != passwordConfirmationTextBox.Text)
            {
                MessageBox.Show("パスワードとパスワード(確認)は同じ値を入力してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("パスワードとパスワード(確認)の入力値が一致していない。");
            }
            else
            {
                var userId = _user.UserId;
                var newUserName = userNameTextBox.Text;

                HashedPassword hash = new HashedPassword();
                var hashedNewPassword = hash.GetHashedTextString(passwordTextBox.Text);

                DateTime newStartDate = startEffectiveDateTimePicker.Value;
                DateTime newEndingDate = endingEffectiveDateTimePicker.Value;

                DbManager.UpdateUserInfo(userId, newUserName, hashedNewPassword, newStartDate, newEndingDate);

                MessageBox.Show("ユーザー情報を変更しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.None);
                logger.Info("userId：" + userId + "のユーザー情報を変更しました。");
            }
        }

        #endregion

        #region 変更キャンセル
        /// <summary>
        /// キャンセルボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancellButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
