using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5, m = 5;
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j > i && j < n - 1 - i)
                        a[i, j] = 1;
                    if (j > i && j > n - 1 - i)
                        a[i, j] = 2;
                    if (j < i && j > n - 1 - i)
                        a[i, j] = 3;
                    if (j < i && j < n - 1 - i)
                        a[i, j] = 4;
                }
            }
			
			
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < m; j++)
                    Console.Write(a[i,j]+" ");
               
                 
            }
            Console.ReadKey();
        }
    }
}
