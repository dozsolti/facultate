using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication48
{
    class Program
    {
        public static bool isUnic(int[] v)
        {
            for (int i = 0; i < v.Length - 1; i++)
                for (int j = i + 1; j < v.Length; j++)
                    if (v[i] == v[j])
                        return false;
            return true;
        }
        static public void Back(int k, int n, int p, int[] sol, bool[] b)
        {
            if (k > p)
            {
                for (int i = 1; i <= p; i++)
                    Console.Write(sol[i] + " ");
                Console.WriteLine();
            }
            else
            {
                for (int i = sol[k - 1]; i < n; i++)
                {
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Back(k + 1, n, p, sol, b);
                        b[i] = false;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int n = 5, p = 3;
            int[] sol = new int[p + 1];
            sol[0] = 0;
            bool[] b = new bool[n];
            Back(1, n, p, sol, b);
            Console.ReadKey();
        }
    }
}
