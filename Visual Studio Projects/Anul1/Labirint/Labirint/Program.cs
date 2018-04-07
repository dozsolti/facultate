using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirint
{
    class Program
    {
        static Random r = new Random();
        static int l, c;
        static int[,] a;
        static bool[,] b;
        static bool ok;

        static void Main(string[] args)
        {
            l = 5; c = 10;

            a = new int[l, c]; b = new bool[l, c];
            for (int i = 0; i < l; i++)
                for (int j = 0; j < c; j++)
                    a[i, j] = r.Next(2);

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                    Console.Write(a[i,j]+" ");
                Console.WriteLine();
            }
            ok = false;
            for (int i = 0; i < l; i++)
                if(a[i,0]==1)
                    Parcurgere(i,0);
            if (ok == true) Console.WriteLine("Da");
            else Console.WriteLine("Nu");
            Console.ReadKey();
        }

        private static void Parcurgere(int i,int j)
        {
            if (i >= 0 && i < l && j >= 0 && j < c && b[i, j] == false && a[i, j] == 1)
            {
                b[i, j] = true;
                if (j == c - 1) ok = true;
                //Dan Noje
                //074 463 2883
                
                Parcurgere(i - 1, j);
                Parcurgere(i, j - 1);
                Parcurgere(i + 1, j);
                Parcurgere(i, j + 1);
            }

        }
    }
}
