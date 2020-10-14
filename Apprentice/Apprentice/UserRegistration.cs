using ClassLibrary;
using DatabaseManager;
using log4net;
using System;
using System.Windows.Forms;

namespace Apprentice
{
    public partial class UserRegistration : Form
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserRegistration()
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
        /// 有効期限の初期設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserRegistrationLoad(object sender, EventArgs e)
        {
            startEffectiveDateTimePicker.Value = DateTime.Today;
            endingEffectiveDateTimePicker.Value = DateTime.Today.AddYears(1);
        }

        #endregion

        #region 登録

        /// <summary>
        /// 登録ボタンを押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButtonClick(object sender, EventArgs e)
        {
            if (DbManager.FindUserId(userIdTextBox.Text) != null)
            {
                MessageBox.Show("このユーザーIDは登録されています。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("入力されたユーザーIDは既に登録されている。");
            }
            else if (userIdTextBox.TextLength < 4)
            {
                MessageBox.Show("ユーザーIDは4文字以上、32文字以内で入力してください。", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("入力されたユーザーIDが文字数制限を満たしていない。");
            }
            else if (userNameTextBox.TextLength < 1)
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
                var userName = userNameTextBox.Text;
                var userId = userIdTextBox.Text;

                HashedPassword hash = new HashedPassword();
                var hashedNewPassword = hash.GetHashedTextString(passwordTextBox.Text);

                DateTime startDate = startEffectiveDateTimePicker.Value;
                DateTime endingDate = endingEffectiveDateTimePicker.Value;

                DbManager.RegisterUser(userName, userId, hashedNewPassword, startDate, endingDate);

                MessageBox.Show("登録しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.None);
                logger.Info("userId:" + userId + "を新規登録しました。");
            }
        }

        #endregion

        #region 登録キャンセル
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
