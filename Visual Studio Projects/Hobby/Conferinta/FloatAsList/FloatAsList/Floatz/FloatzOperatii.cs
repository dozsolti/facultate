using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        
        public static Floatz operator +(Floatz a, Floatz b)
        {
            List<int> cZecimala = Add(a.zecimala, b.zecimala);
            List<int> cIntreaga = Add(a.intreaga, b.intreaga);
            if (cZecimala.Count > Math.Max(a.zecimala.Count,b.zecimala.Count))
            {
                cZecimala.RemoveAt(0);
                cIntreaga = Add(cIntreaga, new List<int> { 1 });
            }
            Floatz c = new Floatz(cIntreaga, cZecimala);
            return c;
        }
        private static int[] Add(int[] v1, int[] v2)
        {

            v1 = Reverse(v1);
            v2 = Reverse(v2);
            int minLen = Math.Min(v1.Length, v2.Length);
            int maxLen = Math.Max(v1.Length, v2.Length);
            int[] a = new int[maxLen + 1];
            
            for (int i = 0; i < minLen; i++)
                a[i] = v1[i] + v2[i];

            for (int i = v1.Length; i < maxLen; i++)
                a[i] = v2[i];

            for (int i = v2.Length; i < maxLen; i++)
                a[i] = v1[i];

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > 9)
                {
                    a[i + 1]++;
                    a[i] %= 10;
                }
            }
            a = Reverse(a);
            if (a.Length > 1)
                a = Repara(a);
            return a;
        }

        private static List<int> Add(List<int> v1, List<int> v2)
        {
            return Add(v1.ToArray(), v2.ToArray()).ToList();
        }

        private static int[] Reverse(int[] a)
        {
            for (int i = 0; i < a.Length / 2; i++)
            {
                int temp = a[i];
                a[i] = a[a.Length - 1 - i];
                a[a.Length - 1 - i] = temp;
            }
            return a;
        }
        private static int[] Reverse(List<int> a)
        {
            for (int i = 0; i < a.Count / 2; i++)
            {
                int temp = a[i];
                a[i] = a[a.Count - 1 - i];
                a[a.Count - 1 - i] = temp;
            }
            return a.ToArray();
        }

        private static List<int> Repara(List<int> v)
        {
            return Repara(v.ToArray()).ToList();
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