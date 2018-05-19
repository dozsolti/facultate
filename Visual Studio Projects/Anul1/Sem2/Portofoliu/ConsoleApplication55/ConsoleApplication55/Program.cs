using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication55
{
    class Program
    {
        static int[] v = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Inainte de mutatie:");
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i]);
            Console.WriteLine();
            for (int i = 0; i < v.Length; i++)
                if (rnd.Next(10) < rnd.Next(10))
                    v[i] = rnd.Next(10);

            Console.WriteLine("Dupa de mutatie:");
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i]);


            Console.ReadKey();
        }
    }
}
