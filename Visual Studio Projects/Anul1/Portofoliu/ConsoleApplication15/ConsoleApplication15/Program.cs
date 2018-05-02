using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v1 = { 1, 2, 3 };
            int[] v2 = { 4,5,6 };
            int[] v3 = concat(v1, v2);
            for(int i = 0; i < v3.Length; i++)
            {
                Console.Write(v3[i]);
            }
            Console.ReadKey();
        }

        private static int[] concat(int[] v1, int[] v2)
        {
            int[] v3 = new int[v1.Length + v2.Length];
            for (int i = 0; i < v1.Length; i++)
                v3[i] = v1[i];
            
            for (int i = 0; i < v2.Length; i++)
                v3[v1.Length+i] = v2[i];

            return v3;
        }
    }
}
