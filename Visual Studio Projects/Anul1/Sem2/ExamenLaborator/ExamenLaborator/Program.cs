using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenLaborator
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = 5;
            int[] v = new int[n];
            bool[] b = new bool[n];
            back(n, v, b,0);
            Console.ReadKey();
        }

        private static void back(int n, int[] v, bool[] b,int k)
        {
            if (k >= n)
            {
                if (eBun(v))
                {
                    foreach (int item in v)
                        Console.Write(item + " ");
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (b[i] == false)
                    {
                        v[k] = i;
                        b[i] = true;
                        back(n, v, b, k + 1);
                        b[i] = false;
                    }
                }
            }
        }

        private static bool eBun(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                for (int j = 0; j < v.Length; j++)
                        if (i != j && Math.Abs(i - j) == Math.Abs(v[i]-v[j]))
                            return false;
            return true;
        }
    }
}
