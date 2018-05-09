using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication46
{
    class Program
    {
        static public void Back(int k, int n, int p, int[] sol)
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
                        sol[k] = i;
                        Back(k + 1, n, p, sol);
                }
            }
        }
        static void Main(string[] args)
        {
            int n = 5, p = 3;
            int[] sol = new int[p + 1];
            sol[0] = 0;
            Back(1, n, p, sol);
            Console.ReadKey();
        }
    }
}
