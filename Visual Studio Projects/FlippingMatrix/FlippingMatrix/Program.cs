using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingMatrix
{
    class Program
    {
        static Random rnd;
        static int[,] m;
        static int n;
        static void Main(string[] args)
        {
            rnd = new Random();
            n = 5;
            m = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = rnd.Next(10);
                }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(m[i, j] + "  ");
                }
                Console.WriteLine();
            }

            /*
            Console.WriteLine();
            Console.WriteLine("FlipY:  ");
            FlipY();
            AfiseazaM();
            }*/

            /*Console.WriteLine();
            Console.WriteLine("FlipX:  ");
            FlipX();
            AfiseazaM();*/

            /*Console.WriteLine();
            Console.WriteLine("FlipDp:  ");
            FlipDP();*/
            Console.WriteLine();

            //Console.WriteLine("FlipDS:  ");
            //FlipDS();

            Console.WriteLine("Flip la Stanga");
            Rotate("stanga");
            
            Console.WriteLine("Flip la Dreapta");
            Rotate("dreapta");
            AfiseazaM();

            Console.ReadKey();
        }

        private static void Rotate(string dir)
        {
            if (dir == "stanga")
            {
                int[,] b = new int[n, n];
                for (int i = 0; i <n; i++)
                    for (int j = 0; j <n; j++)
                    {
                        b[n - 1 - j, i] = m[i, j];
                    }
                m = b;
            }
            if (dir == "dreapta")
            {
                int[,] b = new int[n, n];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        b[i,j] = m[n - 1 - j, i];
                    }
                m = b;
            }
        }

        private static void AfiseazaM()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(m[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        private static void FlipDS()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (i + j < n - 1)
                    {
                        int t = n - 1 - (i + j);
                        Swap(ref m[i, j], ref m[i+t, j+t]);
                    }
                }
        }
        private static void FlipDP()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if(i<j)
                        Swap(ref m[i, j], ref m[j, i]);
                }
        }

        private static void FlipX()
        {
            for (int i = 0; i < n/2; i++)
                for (int j = 0; j < n; j++)
                {
                    Swap(ref m[n - 1 - i, j], ref m[i, j]);
                }
        }

        static void FlipY()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n/2; j++)
                {
                    Swap(ref m[i,n-1-j],ref m[i,j]);
                }
        }

        private static void Swap(ref int v1,ref int v2)
        {
            int a=v1;
            v1 = v2;
            v2 = a;
        }
    }
}
