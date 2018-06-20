using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication22
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m,k;
            n = m = 3;
            k = 2;
            int[,] a = new int[n, m];
            for(int i=0;i<a.GetLength(0);i++)
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    while (!isPrim(k))
                        k++;
                    a[i, j] = k;
                    k++;
                }
            for (int i = 0; i < a.GetLength(0); i++) {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i,j]+" ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static bool isPrim(int k)
        {
            if (k == 2)
                return true;
            if (k % 2==0)
                return false;
            int d = 3;
            while (d * d < k)
            {
                if (k % d == 0)
                    return false;
                d += 2;
            }
            return true;
        }
    }
}
