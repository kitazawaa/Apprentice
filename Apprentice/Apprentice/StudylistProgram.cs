using Apprentice;
using log4net;
using System;
using System.Windows.Forms;

namespace Studylist
{
    static class StudyListProgram
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Mutex名
            string mutexName = "StudyListProgram";
            //Mutexオブジェクトを作成する
            bool createdNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, mutexName, out createdNew);

            //ミューテックスの初期所有権が付与されたか調べる
            if (createdNew == false)
            {
                //付与されなかった場合は、すでに起動していると判断して終了
                MessageBox.Show("検査一覧表示編集プログラムはすでに起動しています。");
                logger.Warn("検査一覧表示編集プログラムはすでに起動しています。");
                mutex.Close();
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Login());
                logger.Info("検査一覧表示編集プログラムは正常に起動しました。");
            }
            finally
            {
                //ミューテックスを解放する
                mutex.ReleaseMutex();
                mutex.Close();
            }


        }
    }
}
