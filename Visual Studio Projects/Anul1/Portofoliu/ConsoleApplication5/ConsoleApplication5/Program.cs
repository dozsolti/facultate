using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = n;
            while (n != -1)
            {
                if(min>n)
                    min = n;
                n = int.Parse(Console.ReadLine());
            }
        }
    }
}
