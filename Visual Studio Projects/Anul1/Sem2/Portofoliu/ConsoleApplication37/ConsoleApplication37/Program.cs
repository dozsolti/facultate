using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication37
{
    class Program
    {
        static int n = 5, maxCount, c, maxTer, t;
        static int[,] m = new int[n, n];
        static bool[,] b = new bool[n, n];
        static Random rnd;

        static void Main(string[] args)
        {
            rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    m[i, j] = rnd.Next(3);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                    Console.Write(m[i, j] + " ");
            }

            GetTablouMax();
            Console.WriteLine("({0},{1})", maxCount, maxTer);

            Console.ReadKey();
        }

        private static void GetTablouMax()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (b[i, j] == false && m[i,j]!=0)
                    {
                        c = 0;
                        t = m[i, j];
                        GetTablou(i, j);
                        if (c > maxCount)
                        {
                            maxCount = c;
                            maxTer = m[i, j];
                        }
                    }
                }
        }

        private static void GetTablou(int i, int j)
        {
            if (i >= 0 && i < n && j >= 0 && j < n && t == m[i, j] && b[i, j] == false)
            {
                c++;
                b[i, j] = true;
                GetTablou(i - 1, j);
                GetTablou(i + 1, j);
                GetTablou(i, j - 1);
                GetTablou(i, j + 1);
            }
        }
    }
}
