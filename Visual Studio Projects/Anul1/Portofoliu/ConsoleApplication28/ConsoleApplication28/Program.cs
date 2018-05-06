using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication28
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(factorial(4));
            Console.ReadKey();
        }

        private static int factorial(int n)
        {
            if (n == 1)
                return 1;
            return n * factorial(n - 1);
        }
    }
}
