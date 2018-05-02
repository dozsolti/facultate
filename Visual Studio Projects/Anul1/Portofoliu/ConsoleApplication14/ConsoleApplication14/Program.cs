using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[] { 1, 23, 32, -2, 6, 5, 4, 3, 2, 1 };
            int _temp = 0;
            for (int i = 0; i < v.Length; i++)
                for (int k = i; k > 0 && v[k] < v[k - 1]; k--)
                {
                    _temp = v[k];
                    v[k] = v[k - 1];
                    v[k - 1] = _temp;
                }
            for (int i = 0; i < v.Length; i++)
                Console.Write(" " + v[i]);
            Console.ReadKey();
        }
    }
}
