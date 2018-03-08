using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillWithWater
{
    class Program
    {
        static Random rnd = new Random();
        static int[] m;
        static int[,] a;

        static void gen()
        {
            /*m = new int[rnd.Next(100)];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = rnd.Next(10);
            }*/
            m = new int[] { 2,9,0,1,3,5};
        }
        static void gen2(int x,int y)
        {
            a = new int[x, y];
            //for (int k = 0; k< m.Length; k++)
            {
                for (int i = 0; i < y; i++)
                    for (int j = x - 1; j >=x-m[i]; j--)
                        a[j,i] = 1;
            }
        }

        static bool t(int idx)
        {
            bool left = false;
            bool right = false;

            if (idx == 0)
                return false;
            if (idx == m.Length)
                return false;

            for (int i = idx; i >= 0; i--)
            {
                if (m[i] > m[idx])
                    left = true;
            }
            for (int i = idx; i < m.Length; i++)
            {
                if (m[i] > m[idx])
                    right = true;
            }
            if (left && right)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            //int nrp = 0;
            //for(int i = 0;i< 10000; i++)
            //{
            //    int p = rnd.next(m.length);
            //    if(t(p))
            //    {
            //        m[p]++;
            //        nrp++;
            //    }
            //}
            //console.writeline("m: {0}", print(m));
            //console.writeline("nr picuri: {0}",nrp);
            gen();

            int max = -1;
            for (int i = 0; i < m.Length; i++) {
                if (max < m[i])
                    max = m[i];
            }
            gen2(max,m.Length);
            Console.WriteLine(print());
            execute2(max);
            Console.WriteLine(print());
            Console.ReadKey();

        }

        private static void execute2(int max)
        {
            int j = 0;
            for (int i = 0; i <max; i++) {
                j = 0;
                while (a[i, j] != 1)
                {
                    a[i, j] = 2;
                    j++;
                }
            }
            for (int i = 0; i < max; i++)
            {
                j = m.Length-1;
                while (a[i, j] != 1)
                {
                    a[i, j] = 2;
                    j--;
                }
            }
        }

        static string print() {
            string b = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    b += a[i,j].ToString();
                b += "\n";

            }
            return b;
        }
    }
}
