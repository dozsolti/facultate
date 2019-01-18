using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5
{
    public static class MerkleCryptor
    {
        public static int Encrypt(string message, Key key)
        {
            byte[] m = { 1,0,1,1,0,1 }; // ToByteArray(message);
            int c = 0;
            for (int i = 0; i < Math.Min(m.Length, key.publicK.Length); i++)
                c = c + m[i] * key.publicK[i];
            return c;

        }
        public static byte[] Decrypt(int ciphertext, Key key)
        {
            int d = (getModularInverse(key.privateK.W, key.privateK.M) * ciphertext) % key.privateK.M;
            int[] r = SolveKnapsack(d, key.privateK.b);

            byte[] m = new byte[key.privateK.pi.Length];
            for (int i = 0; i < m.Length; i++)
                m[i] = (byte)r[key.privateK.pi[i]];

            return m;
        }

        #region Functii auxiliare
        private static int getModularInverse(int W, int M)
        {
            for (int i = 0; i < M; i++)
                if ((W * i) % M == 1)
                    return i;
            return 0;
        }
        private static int[] SolveKnapsack(int s, int[] b)
        {
            int[] x = new int[b.Length];
            for(int i = b.Length - 1; i >= 0; i--)
                if (s >= b[i])
                    x[i] = 1;
                else
                    x[i] = 0;

            return x;
        }
        private static byte[] ToByteArray(string value)
        {
            char[] charArr = value.ToCharArray();
            byte[] bytes = new byte[charArr.Length];
            for (int i = 0; i < charArr.Length; i++)
            {
                byte current = Convert.ToByte(charArr[i]);
                bytes[i] = current;
            }

            return bytes;
        }

        #endregion
    }
}
