using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace UniLibs
{
    /// <summary>
    /// AES暗号化、復号化処理
    /// 参考：https://qiita.com/tempura/items/a9b63ce8a32def6a69b1
    /// .NET 2.0 subsetで動作する様に AesCryptoServiceProvider は使用しない
    /// </summary>
    public class AESCrypter
    {
        //Key
        private byte[] m_Key = null;
        public byte[] Key
        {
            get { return m_Key; }
            set { m_Key = value; }
        }
        public string KeyText
        {
            get { return Encoding.UTF8.GetString(Key); }
            set { Key = Encoding.UTF8.GetBytes(value); }
        }

        //InitVector
        private byte[] m_Iv = null;
        public byte[] Iv
        {
            get { return m_Iv; }
            set { m_Iv = value; }
        }
        public string IvText
        {
            get { return Encoding.UTF8.GetString(Iv); }
            set { Iv = Encoding.UTF8.GetBytes(value); }
        }

        //ラインダール設定
        private RijndaelManaged m_Rijndael = null;
        public const int DefaultKeySize = 128;
        public const int DefaultBlockSize = 128;
        public const CipherMode DefaultCipherMode = CipherMode.CBC;
        public const PaddingMode DefaultPaddingMode = PaddingMode.PKCS7;

        public AESCrypter(byte[] key, byte[] iv,
              PaddingMode padMode = DefaultPaddingMode, CipherMode cipMode = DefaultCipherMode,
              int keySize = DefaultKeySize, int blockSize = DefaultBlockSize)
        {
            m_Rijndael = new RijndaelManaged();
            m_Rijndael.Padding = padMode;
            m_Rijndael.Mode = cipMode;
            m_Rijndael.KeySize = keySize;
            m_Rijndael.BlockSize = blockSize;

            Key = key;
            Iv = iv;
        }

        public AESCrypter(string key, string iv,
              PaddingMode padMode = DefaultPaddingMode, CipherMode cipMode = DefaultCipherMode,
              int keySize = DefaultKeySize, int blockSize = DefaultBlockSize)
          : this(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(iv), padMode, cipMode, keySize, blockSize)
        {
        }

        ~AESCrypter()
        {
            if (m_Rijndael != null)
            {
                m_Rijndael.Clear();
            }
            m_Rijndael = null;
        }

        /// <summary>
        /// 暗号化
        /// </summary>
        /// <param name="data">平文バッファ</param>
        /// <returns>暗号化されたバッファ</returns>
        public byte[] Encode(byte[] data)
        {
            using (var encryptor = m_Rijndael.CreateEncryptor(Key, Iv))
            {
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// 復号化（Base64）
        /// </summary>
        /// <param name="data">平文テキスト</param>
        /// <returns>暗号化Base64文字列</returns>
        public string Encode(string text)
        {
            byte[] data = Encode(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// 復号化
        /// </summary>
        /// <param name="encdata">暗号化されたバッファ</param>
        /// <returns>平文バッファ</returns>
        public byte[] Decode(byte[] encdata)
        {
            byte[] data = new byte[encdata.Length];
            using (var decryptor = m_Rijndael.CreateDecryptor(Key, Iv))
            {
                using (var ms = new MemoryStream(encdata))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        var len = cs.Read(data, 0, data.Length);
                        Array.Resize<byte>(ref data, len);
                        return data;
                    }
                }
            }
        }

        /// <summary>
        /// 復号化（Base64）
        /// </summary>
        /// <param name="encdata">暗号化されたBase64文字列</param>
        /// <returns>平文Base64文字列</returns>
        public string Decode(string encbase64)
        {
            byte[] data = Decode(Convert.FromBase64String(encbase64));
            return Encoding.UTF8.GetString(data);
        }
    }
}
