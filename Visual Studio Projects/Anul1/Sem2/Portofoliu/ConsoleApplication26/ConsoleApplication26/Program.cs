using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26
{
    class Program
    {
        static int n = 2;
        static int[,] m = { { 1, 2 }, { 3, 4 } };// new int[n, n];
        static int[,] m2 = { { 2, 0 }, { 1, 2 } }; // new int[n, n];
        static void Main(string[] args)
        {
            /*int q = 0;
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
                }*/

            Console.WriteLine("M1: ");
            printM(m);
            Console.WriteLine();

            Console.WriteLine("M2: ");
            printM(m2);
            Console.WriteLine();

            int[,] mSum = new int[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) {
                    mSum[i, j] = getProduct(i, j);
                }
            }
            printM(mSum);
            Console.ReadKey();
        }

        private static int getProduct(int i, int j)
        {
            int p = 0;
            for(int q=0;q<n;q++)
                p+=m[i,q] * m2[q, j];
            return p;
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