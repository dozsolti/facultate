    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication52
{
    class Program
    {
        static void bk(int k, int n, int[] sol, bool[] fol)
        {
            if (k >= n)
            {
                if (isSol(sol)) //Trebuie sa verific daca se ating pe diagonala
                {
                    Console.WriteLine();
                    Console.WriteLine("Am gasit o solutie:");
                    for (int i = 0; i < n; i++)
                        Console.WriteLine("Plaseaza o regina pe: randul {0} is coloana {1}",i,sol[i]);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                    if (fol[i] == false)
                    {
                        fol[i] = true;
                        sol[k] = i;
                        bk(k + 1, n, sol, fol);
                        fol[i] = false;
                    }
            }
        }

        static bool isSol(int[] v)
        {
            int n = v.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (Math.Abs(i - j) == Math.Abs(v[i] - v[j]))
                        return false;
            return true;
        }

        static void Main(string[] args)
        {
            int k = 0, n = 5;
            int[] sol = new int[n];
            bool[] fol = new bool[n];
            bk(k, n, sol, fol);
            Console.ReadKey();
        }
    
}
}
