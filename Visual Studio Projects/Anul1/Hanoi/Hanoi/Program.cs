﻿using System;
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

         private static void fHanoi(int nr, char a, char b, char c)
        {
            if (nr == 1)
                Console.WriteLine(a + "->" + c);
            else
            {

                fHanoi(nr - 1, a, c, b);
                fHanoi(1, a, b,c);
                fHanoi(nr - 1, b, a, c);
            }
        }
    }
}
