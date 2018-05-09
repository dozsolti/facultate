using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = { -3, 0, 2, 10, 0, -4, -1 }, v2 = new int[v.Length];
            int s = 0, d = v.Length-1;
            foreach(int i in v)
            {
                if (i < 0)
                    v2[s++] = i;
                else if (i > 0)
                    v2[d--] = i;
            }
            for (int i = 0; i < v2.Length; i++)
                Console.Write(v2[i] + " ");
            Console.ReadKey();
        }
    }
}
