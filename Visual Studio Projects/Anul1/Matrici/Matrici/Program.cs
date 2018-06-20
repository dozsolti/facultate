using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrici
{
    class Program
    {
        static int n = 11, m = 11;
        static void Main(string[] args)
        {
            Random r = new Random();
            
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    a[i, j] = 0;//r.Next(10);
            }
            /*Console.WriteLine();
            for (int i = 0; i < n/2; i++)
            {
                int x = ( (n - 1) / 2) - (i% ((n - 1) / 2));
                Console.Write("{0} ",x);
            }*/
            print("Matricia este: ", f3(a));
            Console.ReadKey();
        }

        private static int[,] f1(int[,] a)
        {
            // .\
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    a[i, j] = 1;
                }
            }
            return a;
        }
        private static int[,] f2(int[,] a)
        {
            // \°
            for (int i = 0; i < n; i++)
            {
                for (int j = m-1-i; j < m; j++)
                {
                    a[i, j] = 1;
                }
            }
            return a;
        }
        
        private static int[,] f3(int[,] a)
        {
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
            return a;
        }

        private static int[,] romb(int[,] a)
        {
            for (int i = 0; i < n/2; i++) {
                
                for (int j = ((n - 1) / 2) - (i % ((n - 1) / 2));
                  j <= m-1-( ((n - 1) / 2) - (i % ((n - 1) / 2)));
                j++)
                {
                    a[i, j] = 1;
                    a[n-1-i, j] = 1;
                }
            }

            return a;
        }
        private static int[,] Brad(int[,] a)
        {
            for (int i = 0; i < 8; i++) {
                for (int j = m / 2 - (i % (m/2)); j <= m / 2 + (i % (m / 2)); j++)
                    a[i, j] = 7;
            }
            for (int i = 8; i < n; i++)
            {
                for (int j = m / 2 - 1; j<m/2+1;j++)
                    a[i, j] = 1;
            }
            return a;
        }
        private static void print(string text, int[,] a)
        {
            string toShow = "";
            toShow += text;
            for(int j = 0; j < m; j++) {
                /*if (a[0, j] == 0)
                    toShow += ' ';
                else*/
                    toShow += a[0,j];
            }
            toShow += '\n';
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < text.Length; j++)
                    toShow += ' ';
                for (int j = 0; j < m; j++)
                {
                    /*if(a[i,j]==0)
                        toShow += ' ';
                    else*/
                        toShow += a[i, j];
                }
                toShow += '\n';
            }
            Console.WriteLine(toShow);
        }
    }
}
