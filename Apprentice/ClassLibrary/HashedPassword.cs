﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{
    public class HashedPassword
    {
        /// <summary>
        /// パスワードのハッシュ化
        /// </summary>
        public string GetHashedTextString(string passwd)
        {
            // パスワードをUTF-8エンコードでバイト配列として取り出す
            byte[] byteValues = Encoding.UTF8.GetBytes(passwd);

            // SHA256のハッシュ値を計算する
            SHA256 crypto256 = new SHA256CryptoServiceProvider();
            byte[] hash256Value = crypto256.ComputeHash(byteValues);

            // SHA256の計算結果をUTF8で文字列として取り出す
            StringBuilder hashedText = new StringBuilder();
            for (int i = 0; i < hash256Value.Length; i++)
            {
                // 16進の数値を文字列として取り出す
                hashedText.AppendFormat("{0:X2}", hash256Value[i]);
            }
            return hashedText.ToString();
        }

    }
}
