using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication48
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 50, p = 3;
            int[] sol = new int[p + 1];
            bool[] b = new bool[n];
            Combinari(1, n, p, sol, b);
            Console.ReadKey();
        }
        static public void Combinari(int k, int n, int p, int[] sol, bool[] b)
        {
            if (k > p)
            {
                for (int i = 1; i <= p; i++)
                    Console.Write((sol[i]) + " ");
                Console.WriteLine();
            }
            else
                for (int i = sol[k - 1] + 1; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Combinari(k + 1, n, p, sol, b);
                        b[i] = false;
                    }
        }
    }
}
