using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v1 = { 1, 2, 3 };
            int[] v2 = { 1, 5, 3 };
            int[] v3 = reuniune(v1, v2);
            for (int i = 0; i < v3.Length; i++)
            {
                Console.Write(v3[i]);
            }
            Console.ReadKey();
        }

        private static int[] reuniune(int[] v1, int[] v2)
        {
            int len = 0;
            for (int i = 0; i < v1.Length; i++)
                for (int j = 0; j < v2.Length; j++)
                    if (v1[i] == v2[j])
                        len++;
            int[] v3 = new int[len];
            int k = 0;
            for (int i = 0; i < v1.Length; i++)
                for (int j = 0; j < v2.Length; j++)
                    if (v1[i] == v2[j])
                    {
                        v3[k] = v1[i];
                        k++;
                    }
            return v3;
        }
    }

}
