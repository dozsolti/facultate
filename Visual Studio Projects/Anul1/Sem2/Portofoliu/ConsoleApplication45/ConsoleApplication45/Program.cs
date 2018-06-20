using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication45
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Pow(2, 30));
            Console.ReadKey();
        }

        private static int Pow(int x, int n)
        {
            if (n < 1)
                return 1;
            if (n % 2 == 0)
            {
                int _x = Pow(x, n / 2);
                return _x * _x;
            }
            else
                return x * Pow(x, n - 1);

        }
    }
}
