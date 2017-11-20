using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            fHanoi(5,'a', 'b', 'c');
            Console.ReadKey();
        }

        private static void fHanoi(int nr,char s, char d, char i)
        {
            if (nr == 1)
                Console.WriteLine(s+"->"+d);
            else
            {
                
                fHanoi(nr - 1, s, d, i);
                fHanoi(1, s, i, d);
                fHanoi(nr - 1, i, s, d);
            }
        }
    }
}
