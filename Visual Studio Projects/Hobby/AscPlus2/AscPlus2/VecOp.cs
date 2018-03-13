using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscPlus2
{
    class VecOp
    {
        public  static int[] Add(int[] v1, int[] v2)
        {
            int baza = 2;
            v1 = Reverse(v1);
            v2 = Reverse(v2);
            int minLen = v2.Length;
            int maxLen = v1.Length;
            int[] a = new int[maxLen];

            for (int i = 0; i < minLen; i++)
                a[i] = v1[i] + v2[i];

            for (int i = v1.Length; i < maxLen; i++)
                a[i] = v2[i];

            for (int i = v2.Length; i < maxLen; i++)
                a[i] = v1[i];

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > baza-1)
                {
                    a[i + 1]++;
                    a[i] %= baza;
                }
            }

            return Repara(Reverse(a));
        }

        public static int[] Reverse(int[] a)
        {
            for (int i = 0; i < a.Length / 2; i++)
            {
                int temp = a[i];
                a[i] = a[a.Length - 1 - i];
                a[a.Length - 1 - i] = temp;
            }
            return a;
        }
        private static int[] Repara(int[] v)
        {
            //scoate zerourile din fata
            int k = 0;
            while (v[k] == 0 && k < v.Length - 1)
                k++;

            int[] _temp = new int[v.Length - k];
            for (int i = 0; i < _temp.Length; i++)
                _temp[i] = v[k + i];

            return _temp;
        }
    }
}
