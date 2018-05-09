using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication25
{
    class Program
    {
        static int n = 5;
        static int[,] m = new int[n, n];
        static int[,] m2 = new int[n, n];
        static void Main(string[] args)
        {
            int q = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = q;
                    q++;
                }

            q = n * n;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    m2[i, j] = q;
                    q--;
                }

            Console.WriteLine("M1: ");
            printM(m);
            Console.WriteLine();

            Console.WriteLine("M2: ");
            printM(m2);
            Console.WriteLine();

            int[,] mSum = new int[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    mSum[i, j] = m[i, j] + m2[i, j];
            }
            printM(mSum);
            Console.ReadKey();
        }
        static void printM(int[,] _m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(_m[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
