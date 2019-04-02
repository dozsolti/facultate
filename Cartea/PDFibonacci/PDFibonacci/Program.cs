using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFibonacci
{
    class Program
    {
        //Enunt: Sa se construiasc intr-un tablou unidimensional primele n numere din sirul lui Fibonacci, folosind programarea dinamica.

        static void Main(string[] args)
        {
            int[] serie = Fibonacci(1);

            for(int i=0;i<serie.Length;i++)
                    Console.Write(serie[i]+" ");

            Console.ReadKey();
        }

        static int[] Fibonacci(int n)
        {
            int[] v = new int[n];

            for(int i = 0; i < v.Length; i++)
            {
                if (i < 2)
                    v[i] = i;
                else
                    v[i] = v[i - 1] + v[i - 2];
            }

            return v;
        }
    }
}
