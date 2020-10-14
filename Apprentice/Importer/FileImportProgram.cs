using log4net;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Importer
{
    static class FileImportProgram
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Mutex名
            string mutexName = "FileImportProgram";
            //Mutexオブジェクトを作成する
            bool createdNew;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, mutexName, out createdNew);

            //ミューテックスの初期所有権が付与されたか調べる
            if (createdNew == false)
            {
                //付与されなかった場合は、すでに起動していると判断して終了
                MessageBox.Show("多重起動はできません。");
                logger.Warn("検査依頼データ取り込みプログラムはすでに起動しています。");
                mutex.Close();
                return;
            }
            try
            {
                //OS起動時にプログラムを自動的に実行する
                using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\RunOnce", true))
                {
                    //値の名前に製品名、値のデータに実行ファイルのパスを指定し、書き込む
                    regkey.SetValue(Application.ProductName, Application.ExecutablePath);

                    //閉じる
                    regkey.Close();
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Default());
                logger.Info("検査依頼データ取り込みプログラムは正常に起動しました。");
            }
            catch (Exception e)
            {
                logger.Fatal(e.Message);
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
