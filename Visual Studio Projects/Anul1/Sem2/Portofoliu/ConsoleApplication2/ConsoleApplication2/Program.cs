using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=2, b=3, c=4, d=5, e=6;
            if (a == b && a == c && a == d && a == e)
                Console.WriteLine("Toate sunt egale");
            else if ((a == b && a == c && a == d) || (a == b && a == c && a == e) || (a == b && a == d && a == e) || (a == c && a == d && a == e) || (b == c && b == d && b == e))
                Console.WriteLine("4 sunt egale");
            else if ((a == b && a == c && d == e) || (a == b && a == d && c == e) || (a == b && a == e && c == d) || (a == c && a == d && b == e) || (a == c && a == e && b == d) || (a == d && a == e && b == c) || (b == c && b == d && a == e) || (b == c && b == e && a == d) || (b == d && b == e && a == c) || (c == d && c == e && a == b))
                Console.WriteLine("3 sunt identice, iar celelalte doua sunt si ele identice");
            else if ((a == b && a == c) || (a == b && a == d) || (a == b && a == e) || (a == c && a == d) || (a == c && a == e) || (a == d && a == e) || (b == c && b == d) || (b == c && b == e) || (b == d && b == e) || (c == d && c == e))
                Console.WriteLine("3 sunt egale");
            else if ((a == b && c == d) || (a == b && d == e) || (a == b && c == e) || (a == c && b == d) || (a == c && b == e) || (a == c && d == e) || (a == d && b == c) || (a == d && b == e) || (a == d && c == e) || (a == e && b == c) || (a == e && b == d) || (a == e && c == d))
                Console.WriteLine("2 cate 2 sunt egale");
            else if (a == b || a == c || a == d || a == e || b == c || b == d || b == e || c == d || c == e || d == e)
                Console.WriteLine("2 sunt egale");
            else Console.WriteLine("Nici una nu este egala cu nici una");
            Console.ReadKey();


        }
    }
}
