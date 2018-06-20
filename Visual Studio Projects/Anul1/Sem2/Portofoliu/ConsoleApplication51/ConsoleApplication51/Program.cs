using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication51
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[] sol = new int[n];
            Back(0, n, sol);
            Console.ReadKey();
        }

        private static void Back(int k, int n, int[] sol)
        {
            if (k >= n)
                Afisare(sol);
            else
                for(int i=0;i<n;i++)
                {
                    sol[k] = i;
                    Back(k + 1, n, sol);
                }
        }

        private static void Afisare(int[] sol)
        {
            for (int i = 0; i < sol.Length; i++)
                Console.Write(sol[i]); 
            Console.WriteLine();
        }
    }
}
