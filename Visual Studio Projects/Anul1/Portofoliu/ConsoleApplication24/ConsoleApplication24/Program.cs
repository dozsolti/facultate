using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication24
{
    class Program
    {
        static int n = 5;
        static int[,] m = new int[n, n];
        static void Main(string[] args)
        {
            int q = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = q;
                    q++;
                }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                printSpiral(i);
            }
            Console.ReadKey();
        }

        static void printSpiral(int k)
        {
            for (int j = k; j < n - k - 1; j++)
                Console.Write(m[k, j] + " ");

            for (int i = k + 1; i < n - k - 1; i++)
                Console.Write(m[i, n - k - 1] + " ");

            for (int j = n - k - 1; j >= k; j--)
                Console.Write(m[n - k - 1, j] + " ");

            for (int i = n - k - 1; i > k; i--)
                Console.Write(m[i, k] + " ");
        }
    }
}
