using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( ( isPalindrom(int.Parse(Console.ReadLine())) ? "":"nu" ) + " e palindrom");
        }

        private static bool isPalindrom(int v)
        {
            int _v = v;
            int v2 = 0;
            while (v > 0)
            {
                v2 = v2 * 10 + v % 10;
                v /= 10;
            }
            return (v2 == _v);
        }
    }
}
