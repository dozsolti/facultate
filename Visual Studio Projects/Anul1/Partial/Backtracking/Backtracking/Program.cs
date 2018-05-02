using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtracking
{
    class Program
    {
        static void Main(string[] args)
        {
            //AfiseazaPermutarile(4);
            PlaseazaReginele(5);

            Console.ReadKey();
        }
        static int[] v;
        static bool[] fol;
        private static void AfiseazaPermutarile(int n)
        {
            v = new int[n];
            fol = new bool[n];
            Back(0,n);
        }

        private static void Back(int k,int n)
        {
            if (k == n)
            {
                for(int i = 0; i < v.Length; i++)
                {
                    Console.Write(v[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!fol[i])
                    {
                        v[k] = i;
                        fol[i] = true;
                        Back(k + 1, n);
                        fol[i] = false;
                    }
                }
            }
        }

        private static void PlaseazaReginele(int n)
        {
            int[,] m = new int[n, n];
            v = new int[n];
            fol = new bool[n];
            BackQueen(0, n);

        }

        private static void BackQueen(int k, int n)
        {
            if (k == n)
            {
                {
                    for (int i = 0; i < v.Length; i++)
                    {
                        Console.Write(v[i]);
                    }
                    Console.WriteLine();
                }
            }else
            {
                for(int i = 0; i < n; i++)
                {
                    if (!fol[i] && eValid(i))
                    {
                        v[k] = i;
                        fol[k] = true;
                        BackQueen(k + 1, n);
                        fol[k] = false;
                    }
                }
            }
        }

        private static bool eValid(int k)
        {
            for(int i = 0; i < k; i++)
            {
                if(v[i]==v[k] || Math.Abs(k -i)== Math.Abs(v[i] - v[k]))
                    return false;
            }
            return true;
        }
    }
}
