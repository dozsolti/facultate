using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(isPrim(int.Parse(Console.ReadLine())) ? "E prim" : "Nu e prim");
        }

        private static bool isPrim(int v)
        {
            if (v == 2)
                return true;

            if (v % 2 == 0)
                return false;

            int d = 3;
            while (d*d<v)
            {
                d += 2;
                if (v % d == 0)
                    return false;
            }
            return true;
        }
    }
}
