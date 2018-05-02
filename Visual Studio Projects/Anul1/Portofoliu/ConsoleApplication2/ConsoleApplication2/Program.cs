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
            if( a == b || a == c || a == d || a == e ||
                b == c || b == d || b == e ||
                c == d || c == e ||
                d == e )
            {
                Console.WriteLine("2 numere sunt identice");
                return;
            }


        }
    }
}
