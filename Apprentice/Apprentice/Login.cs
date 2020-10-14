using ClassLibrary;
using DatabaseManager;
using Entity;
using log4net;
using System;
using System.Windows.Forms;

namespace Apprentice
{
    public partial class Login : Form
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            Users user = DbManager.FindUserId(userIdTextBox.Text);

            var dt = DateTime.Now;

            //パスワードをハッシュ化
            HashedPassword hash = new HashedPassword();
            var hashedPassword = hash.GetHashedTextString(passwordTextBox.Text);

            //ログイン条件
            if (user == null)
            {
                MessageBox.Show("ユーザーIDが正しくありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("ログインに失敗しました。正しいユーザーIDを入力してください。");
            }
            else if (user.Password != hashedPassword)
            {
                MessageBox.Show("パスワードが正しくありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("ログインに失敗しました。正しいパスワードを入力してください。");
            }
            else if (user.StartedOn > dt || dt > user.ExpiredOn)
            {
                MessageBox.Show("パスワードの有効期限が切れています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Warn("ログインに失敗しました。パスワード変更ボタンから新しいパスワードを設定してください。");
            }
            else
            {
                userIdTextBox.Clear();
                passwordTextBox.Clear();

                StudyList studylist = new StudyList(user);
                studylist.ShowDialog();                             

                logger.Info("ユーザーID" + user.UserId + "がログインしました。");
            }
        }

        private void PasswordChangeLinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userIdTextBox.Clear();
            passwordTextBox.Clear();

            PasswordChange passwordChange = new PasswordChange();
            passwordChange.ShowDialog();
        }
    }
}
