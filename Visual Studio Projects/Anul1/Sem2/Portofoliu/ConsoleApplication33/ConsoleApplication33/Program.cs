using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication33
{
    class Program
    {
        static void Main(string[] args)
        {
            Hanoi(5, 'a', 'b', 'c');
            Console.ReadKey();
        }

        private static void Hanoi(int nr, char a, char b, char c)
        {
            if (nr == 1)
                Console.WriteLine(a + "->" + c);
            else
            {

                Hanoi(nr - 1, a, c, b);
                Hanoi(1, a, b,c);
                Hanoi(nr - 1, b, a, c);
            }
        }
    }
}
