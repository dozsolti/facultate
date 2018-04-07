using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExercitiiCuBacktracking
{
    class Program
    {
        static int[,] a;
        static List<string> T = new List<string>();
        static int l, c,t,v,max;
        static bool[,] b;

        static void Main(string[] args)
        {
            string buffer = "";
            TextReader dLoad = new StreamReader(@"..\..\TextFile1.txt");
            while ((buffer = dLoad.ReadLine()) != null)
                T.Add(buffer);
            l = T.Count;
            c = T[0].Split(' ').Length;
            a = new int[l, c];
            b = new bool[l, c];
            //Ma asigur ca b[i,j] este false

            for (int i = 0; i < l; i++)
            {
                string[] local = T[i].Split(' ');
                for (int j = 0; j < c; j++)
                    a[i, j] = int.Parse(local[j]);
            }
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
            max = 0;
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (b[i, j] == false)
                    {
                        v = 0;
                        t = a[i, j];
                        Parcurgere(i, j);
                        Console.WriteLine(v);
                        if (v > max)
                            max = v;
                    }
                }
            }
            Console.WriteLine(max);
            Console.ReadKey();
        }

        static void Parcurgere(int i, int j)
        {
            if (i >= 0 && i < l && j >= 0 && j < c && b[i, j] == false && a[i,j]==t)
            {
                v++;
                b[i, j] = true;
                //Console.WriteLine(a[i, j] + " "); Console.ReadKey();
                Parcurgere(i - 1, j);
                Parcurgere(i, j + 1);
                Parcurgere(i + 1, j);
                Parcurgere(i, j - 1);
            }
        }
    }
}
