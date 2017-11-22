using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _500Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[1];
            int[] b = new int[] { 8,9,4,5,2 }, a = new int[] { 1,8,9,2,5,0 };

            v = Substract(a, b);

            /*v = Multiply(new int[] { 1 }, new int[] { 2 });
            for (int i = 3; i <= 500; i ++) {
                v = Multiply(v,nToV(i));
            }*/


            printCuMinus("V", v);
            Console.ReadKey();
        }

        private static int Compare(int[] v1, int[] v2)
        {
            if (v1.Length > v2.Length)
                return 1;
            else if (v1.Length < v2.Length)
                return -1;
            else
            {
                for(int i=0;i<v1.Length;i++)
                {
                    if (v1[i] > v2[i])
                        return 1;
                    else if (v1[i] < v2[i])
                        return -1;
                }
                return 0;
            }
        }

        private static int[] Substract(int[] a, int[] b)
        {
            int comp = Compare(a, b);
            if (comp == -1)// => a<b
            {
                int[] _temp = a;
                a = b;
                b = _temp;
            }

            int[] v = new int[a.Length];
            // a = max(a,b)
            // b = min(a,b)
            a = Reverse(a);
            b = Reverse(b);

            for(int i = 0; i < b.Length; i++)
            {
                v[i] = a[i] - b[i];
                if (v[i] < 0)
                {
                    v[i] = a[i] +10 - b[i];
                    a[i + 1]--;
                }
            }
            // for v.length ->a.length
            // v[i]=a[i]
            for (int i = b.Length; i < a.Length; i++)
            {
                v[i] = a[i];
            }

            v = Reverse(v);
            v = Repara(v);
            if (comp == -1)
            {
                v = Reverse(v);
                int[] _temp = new int[v.Length + 1];
                for (int i = 0; i < v.Length; i++)
                    _temp[i] = v[i];
                _temp[_temp.Length - 1] = -1;
                v = _temp;
                v = Reverse(v);
            }
            return v;
        }

        private static int[] nToV(int n)
        {
            int nLength = 0;
            int _tempN = n;
            while(_tempN>0)
            {
                nLength++;
                _tempN /= 10;
            }
            int[] v = new int[nLength];
            for(int i = 0; i < v.Length; i++)
            {
                v[i] = n % 10;
                n /= 10;
            }
            return Reverse(v);
        }

        private static int[] Multiply(int[] a, int[] b)
        {
            //Ca b sa aiba cea mai mica lungime
            if (b.Length > a.Length)
            {
                int[] _temp = a;
                a = b;
                b = _temp;
            }

            int[] m = new int[a.Length];
            a = Reverse(a);
            b = Reverse(b);
            int[] currentMult = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                currentMult[i] = a[i];
            
            for (int i = 0; i < b.Length; i++)
            {
                for (int k = 0; k < a.Length; k++)
                    currentMult[k] = a[k];
                for (int j = 0; j < currentMult.Length; j++) {
                    currentMult[j] *= b[i];
                }
                for (int j = 0; j < currentMult.Length; j++)
                {
                    if (currentMult[j] > 9)
                    {
                        currentMult = AddToNext(currentMult, j);
                        currentMult[j] %= 10;
                    }
                }
                currentMult = Reverse(AddOffset(currentMult, i));
                m = Add(m, currentMult);
            }
            //m = Repara(m);
            return m;
        }

        private static int[] AddOffset(int[] currentMult, int n)
        {
            if (n == 0)
                return currentMult;

            currentMult = Reverse(currentMult);
            //Adauga zero(urile)
            {
                int[] _temp = new int[currentMult.Length + n];
                for (int i = 0; i < currentMult.Length; i++)
                    _temp[i] = currentMult[i];
                currentMult = _temp;
            }
            currentMult = Reverse(currentMult);
            return currentMult;
        }
        private static int[] AddToNext(int[] currentMult, int j)
        {
            if (j >= currentMult.Length - 1)
            {
                int[] _temp = new int[currentMult.Length + 1];
                for (int i = 0; i < currentMult.Length; i++)
                    _temp[i] = currentMult[i];
                _temp[_temp.Length - 1] = currentMult[j] / 10;
                currentMult = _temp;
            }
            else
            {
                currentMult[j + 1] += currentMult[j] / 10;
            }
            return currentMult;
        }
        
        private static int[] Add(int[] v1, int[] v2)
        {

            v1 = Reverse(v1);
            v2 = Reverse(v2);
            int minLen = Math.Min(v1.Length, v2.Length);
            int maxLen = Math.Max(v1.Length, v2.Length);
            int[] a = new int[maxLen+1];

            for (int i = 0; i < minLen; i++)
                a[i] = v1[i]+v2[i];

            for (int i = v1.Length; i < maxLen; i++)
                a[i] = v2[i];

            for (int i = v2.Length; i < maxLen; i++)
                a[i] = v1[i];

            for (int i = 0; i < a.Length-1; i++)
            {
                if (a[i] > 9) {
                    a[i + 1]++;
                    a[i] %= 10;
                }
            }
            
            return Reverse(a);
        }

        private static int[] Reverse(int[] a)
        {
            for(int i = 0; i < a.Length/2; i++) {
                int temp = a[i];
                a[i] = a[a.Length-1-i];
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

        private static void printCuMinus(string name, int[] a)
        {
            string str = "";
            if (a[0] == -1)
                str = "-";

            for (int i = 1; i < a.Length; i++)
            {
                str += a[i].ToString() + "";
            }
            Console.WriteLine(name + " : {0}", str);
        }
        private static void print(string name, int[] a)
        {
            string str = "";
            for (int i = 0; i < a.Length; i++)
            {
                str += a[i].ToString() + "";
                //if (i % 3 == 0 && i<a.Length-1)
                //    str += '.';
            }
            Console.WriteLine(name + " : {0}", str);
        }
    }
}
