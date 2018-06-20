using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[,]
            {
                { 1,2,3 },
                {4,5,6 },
                {7,8,9 }
            };
            int[,] b = new int[,]
            {
                {5,8 },
                {8,9 }
            };
            Console.WriteLine("a {0}il contine pe b", (contine(a, b) ? "" : "nu "));
            Console.ReadKey();
        }

        private static bool contine(int[,] a, int[,] b)
        {
            if (a.GetLength(0) < b.GetLength(0) || a.GetLength(1) < b.GetLength(1))
                return false;

            for (int i = 0; i <= a.GetLength(0)-b.GetLength(0); i++)
                for (int j = 0; j <= a.GetLength(1)-b.GetLength(1); j++)
                    if (incearca(i, j,a, b))
                        return true;
            return false;
        }

        private static bool incearca(int startI, int startJ,int[,] a, int[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    if (a[i+startI,j+startJ] != b[i,j])
                        return false;
            return true;
        }
    }
}
