using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrici2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[5,5];
            int n = 4;
            int k = 0;
            int nrIt = 0;
            for (int i = 0; i <= 2 * n - 1; i++)
            {
                nrIt++;
                if (i <= n)
                {
                    // /
                    for (int j = 0; j < i; j++)
                    {
                        nrIt++;
                        k++;
                        a[j,i-1-j] = k;
            
                    }

                }
                else
                {
                    // /
                    int _i = i % n;
                    Console.WriteLine("_: " + (n+1-_i));
                    for (int j = 0; j < (n+1-_i); j++)
                    {
                        nrIt++;
                        k++;
                        a[_i, n-_i] = k;
                        Console.WriteLine("i: "+_i+" j: "+j);

                    }
                    
                }


            }
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i,j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("nrIt: "+nrIt);
            Console.ReadKey();


        }
    }
}
