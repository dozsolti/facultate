using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5
{
    public static class MerkleKeyFactory
    {
        static Random rnd = new Random();

        public static Key GenerateKey(int n, int[] b)
        {

            int M = 737;//GetMFromB(b);

            int W = 635;// GetWFromM(M);

            int[] pi = { 2,5,0,1,4,3 };// GetRandomPermutation(n);

            int[] a = new int[n];
            for(int i = 0; i < a.Length; i++)
                a[i] = W * b[pi[i]] % M;
            
            return new Key(a, M, W, pi, b);
        }
                
        #region Functii auxiliare
        private static int GetMFromB(int[] b)
        {
            int M = rnd.Next(1, 10);
            foreach (int x in b)
                M += x;
            return M;
        }

        private static int GetWFromM(int M)
        {
            int W = rnd.Next(1, M);
            while(gcd(W,M)!=1)
                W = rnd.Next(1, M);
            return W;
        }
        private static int gcd(int a, int b)
        {
            int r = 0;
            do
            {
                r = a % b;
                a = b;
                b = r;
            } while (b != 0);
            return a;
        }

        private static int[] GetRandomPermutation(int length)
        {
            int[] pi = new int[length];
            for (int i = 0; i < pi.Length; i++)
                pi[i] = i + 1;
            for(int i=pi.Length-1;i>0;i--)
            {
                int j = rnd.Next(0, i+1);
                int temp = pi[i];
                pi[i] = pi[j];
                pi[j] = temp;
            }
            return pi;
        }
        #endregion
    }
}
