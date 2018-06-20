using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication47
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int p = 3;
            int[] sol = new int[p];
            bool[] b = new bool[n];
            Aran(0, n, p, sol, b);
            Console.ReadKey();
        }
        static public void Aran(int k, int n, int p, int[] sol, bool[] b)
        {
            if (k >= p)
            {
                for (int i = 0; i < p; i++)
                    Console.Write((sol[i] + 1) + " ");
                Console.WriteLine();
            }
            else
                for (int i = 0; i < n; i++)
                    if (b[i] == false)
                    {
                        b[i] = true;
                        sol[k] = i;
                        Aran(k + 1, n, p, sol, b);
                        b[i] = false;
                    }
        }
    }
}
