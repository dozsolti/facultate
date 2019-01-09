using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Tema2WPF
{
    public enum types { AES, DES, RC2, Triple_DES };
    public static class Engine
    {
        public static types algorithmType;
        
        private static PaddingMode paddingMode = PaddingMode.ANSIX923;
        private static CipherMode chiperMode = CipherMode.CBC;

        private static byte[] key, iv;
        private static string outputFilePath;

        private static FileStream input;
        public static string Key { get => BitConverter.ToString(key); }
        public static string Iv { get => BitConverter.ToString(iv); }
        public static object Input { get => (FileStream)input; set => input = new FileStream(value.ToString(), FileMode.Open, FileAccess.Read); }

        public static void Generate()
        {
            using (SymmetricAlgorithm alg = GetAlgorithm())
            {
                key = alg.Key;
                iv = alg.IV;
            }
        }

        public static void Crypt()
        {
            using (SymmetricAlgorithm alg = GetAlgorithm())
            {
                alg.Key = key;
                alg.IV = iv;
                alg.Padding = paddingMode;
                alg.Mode = chiperMode;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    String fileName = saveFileDialog.FileName;
                    if (fileName != "")
                    {
                        outputFilePath = fileName;
                        FileStream fout = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                        fout.SetLength(0);

                        CryptoStream encStream = new CryptoStream(fout, alg.CreateEncryptor(), CryptoStreamMode.Write);

                        byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
                        long rdlen = 0;              //This is the total number of bytes written.
                        long totlen = input.Length;    //This is the total length of the input file.
                        int len;                     //This is the number of bytes to be written at a time.

                        while (rdlen < totlen)
                        {
                            len = input.Read(bin, 0, 100);
                            encStream.Write(bin, 0, len);
                            rdlen = rdlen + len;
                        }
                        encStream.Close();
                        fout.Close();
                        input.Close();
                    }
                }
                
            }
        }
        public static void Decrypt()
        {
            using (SymmetricAlgorithm alg = GetAlgorithm())
            {
                alg.Key = key;
                alg.IV = iv;
                alg.Padding = paddingMode;
                alg.Mode = chiperMode;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    String fileName = saveFileDialog.FileName;
                    if (fileName != "")
                    {
                        outputFilePath = fileName;
                        FileStream fout = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                        fout.SetLength(0);

                        CryptoStream decStream = new CryptoStream(fout, alg.CreateDecryptor(), CryptoStreamMode.Write);

                        byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
                        long rdlen = 0;              //This is the total number of bytes written.
                        long totlen = input.Length;    //This is the total length of the input file.
                        int len;                     //This is the number of bytes to be written at a time.
                        while (rdlen < totlen)
                        {
                            len = input.Read(bin, 0, 100);
                            decStream.Write(bin, 0, len);
                            rdlen = rdlen + len;
                        }
                        decStream.Close();
                        fout.Close();
                        input.Close();
                    }
                }

            }
        }


        private static SymmetricAlgorithm GetAlgorithm()
        {
            
            switch (algorithmType)
            {
                case types.AES:
                    return Aes.Create();

                case types.DES:
                    return DES.Create();

                case types.RC2:
                    return RC2.Create();

                case types.Triple_DES:
                    return TripleDESCryptoServiceProvider.Create();

                default:
                    return Aes.Create();
            }
        }
        public static void SetAlgorithmType(string type)
        {
            switch (type)
            {
                case "AES":
                    algorithmType = types.AES;
                    break;
                case "DES":
                    algorithmType = types.DES;
                    break;
                case "RC2":
                    algorithmType = types.RC2;
                    break;
                case "Triple_DES":
                    algorithmType = types.Triple_DES;
                    break;
            }
        }
        public static void SetPaddingType(string type)
        {
            switch (type)
            {
                case "X923":
                    paddingMode = PaddingMode.ANSIX923;
                    break;

                case "PKCS7":
                    paddingMode = PaddingMode.PKCS7;
                    break;

                case "Zeros":
                    paddingMode = PaddingMode.Zeros;
                    break;
                case "ISO10126":
                    paddingMode = PaddingMode.ISO10126;
                    break;
            }
        }
        public static void SetChiperMode(string mode)
        {
            switch (mode)
            {
                case "CBC":
                    chiperMode = CipherMode.CBC;
                    break;
                case "ECB":
                    chiperMode = CipherMode.ECB;
                    break;
                case "OFB":
                    chiperMode = CipherMode.OFB;
                    break;
                case "CFB":
                    chiperMode = CipherMode.CFB;
                    break;
                case "CTS":
                    chiperMode = CipherMode.CTS;
                    break;
            }
        }
        static byte[] GetBytes(string str)
        {
            char[] charArr = str.ToCharArray();
            byte[] bytes = new byte[charArr.Length];
            for (int i = 0; i < charArr.Length; i++)
            {
                byte current = Convert.ToByte(charArr[i]);
                bytes[i] = current;
            }

            return bytes;
        }

    }
}