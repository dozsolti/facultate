using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication50
{
    class Program
    {
        static public void Back(int k, int n, int[] sol)
        {
            if (k > n)
            {
                if (isBun(n, sol))
                {
                    for (int i = 1; i <= n; i++)
                    {
                        if (sol[i] != 0)
                        {
                            Console.Write(sol[i]);
                            if (i != n)
                                Console.Write("+");
                        }
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = sol[k - 1]; i < n; i++)
                {
                    sol[k] = i;
                    Back(k + 1, n, sol);
                }
            }
        }

        private static bool isBun(int n, int[] sol)
        {
            int sum = 0;
            foreach (int item in sol)
                sum += item;
            return sum == n;
        }

        static void Main(string[] args)
        {
            int n = 4;
            int[] sol = new int[n + 1];
            sol[0] = 0;
            Back(1, n, sol);
            Console.ReadKey();
        }
    }
}
