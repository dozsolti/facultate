using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication29
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci(4);
            Console.ReadKey();
        }

        private static void Fibonacci(int n, int k = 0,int a=1,int b=1)
        {
            if (n == k)
                return;
            if(k==0)
                Console.Write(a+" ");
            Console.Write("{0} ",b);
            Fibonnaci(n, k + 1,b,a+b);
        }
    }
}
