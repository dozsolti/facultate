using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[3];
            int sum = 0, prod = 1;
            for(int i = 0; i < v.Length; i++)
            {
                sum += v[i];
                prod *= v[i];
            }
            Console.WriteLine("suma: "+sum);
            Console.WriteLine("prod: " + prod);
            Console.WriteLine("norm: "+sum/v.Length);
        }
    }
}
