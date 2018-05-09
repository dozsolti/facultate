using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication44
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 2, 3, 7, 9, 10, 11, 15, 21, 24, 30 };
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine((Cauta(v, x, 0, v.Length - 1) ? "":"nu ") +"am gasit");
            Console.ReadKey();
        }
        static bool Cauta(int[] v, int n, int startIndx, int endIndex)
        {
            if (startIndx > endIndex)
                return false;

           int m = (startIndx + endIndex) / 2;

           if (v[m] == n)
                return true;

            return (n > v[m]) ? Cauta(v, n, m + 1, endIndex) : Cauta(v, n, startIndx, m - 1);
        }
    }
}
