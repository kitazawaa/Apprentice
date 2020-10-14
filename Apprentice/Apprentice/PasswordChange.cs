using ClassLibrary;
using DatabaseManager;
using Entity;
using log4net;
using System;
using System.Windows.Forms;

namespace Apprentice
{
    public partial class PasswordChange : Form
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PasswordChange()
        {
            InitializeComponent();
        }

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

        /// <summary>
        ///有効期限の初期設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordChangeLoad(object sender, EventArgs e)
        {
            startEffectiveDateTimePicker.Value = DateTime.Today;
            endingEffectiveDateTimePicker.Value = DateTime.Today.AddYears(1);
        }

        #endregion

        #region 変更ボタンを押下
        /// <summary>
        /// パスワード変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButtonClick(object sender, EventArgs e)
        {
            var inputUseId = userIdTextBox.Text;

            var inputCurrentPassword = currentPasswordTextBox.Text;

            HashedPassword hash = new HashedPassword();

            var hashedCurrentPassword = hash.GetHashedTextString(inputCurrentPassword);

            Users user = DbManager.FindUserId(inputUseId);

            //パスワード変更条件
            if (user.UserId != inputUseId)
            {
                MessageBox.Show("ユーザーIDが正しくありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("パスワードの変更に失敗しました。正しいユーザーIDを入力してください。");
            }
            else if (user.Password != hashedCurrentPassword)
            {
                MessageBox.Show("現在のパスワードが正しくありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("パスワードの変更に失敗しました。正しい現在のパスワードを入力してください。");
            }
            else if (newPasswordTextBox.TextLength < 8 || 32 < newPasswordTextBox.TextLength)
            {
                MessageBox.Show("パスワードは8文字以上、32文字以内で入力してください。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("入力されたパスワードが文字数制限を満たしていない。");
            }
            else if (newPasswordTextBox.Text != newPasswordConfirmationTextBox.Text)
            {
                MessageBox.Show("新しいパスワードと新しいパスワード(確認)は同じ値を入力してください。。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("パスワードとパスワード(確認)の入力値が一致していない。");
            }
            else
            {
                var hashedNewPassword = hash.GetHashedTextString(newPasswordTextBox.Text);
                DateTime startDate = startEffectiveDateTimePicker.Value;
                DateTime endingDate = endingEffectiveDateTimePicker.Value;

                DbManager.ChangePassword(inputUseId, hashedNewPassword, startDate, endingDate);

                MessageBox.Show("パスワードを変更しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.None);
                logger.Info("ユーザーID" + user.UserId + "のパスワードを変更しました。");
            }
        }

        #endregion

        #region 戻るボタンを押下
        /// <summary>
        /// ログイン画面に遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


    }
}
