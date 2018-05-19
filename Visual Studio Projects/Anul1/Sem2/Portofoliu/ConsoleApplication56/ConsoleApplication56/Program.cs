using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication56
{
    class Program
    {
        static char[] v1 = new char[] { '1', '2', '3', '4', '5', '6', '7' };
        static char[] v2 = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        static char[] v3 = new char[v1.Length];
        static int[] points = new int[] { 2, 5 };
        static void Main(string[] args)
        {
            bool eDinV1 = true;
            int j = 0;
            for(int i = 0; i < v1.Length; i++)
            {
                if (j < points.Length )
                {
                    if (i >= points[j])
                    {
                        j++;
                        eDinV1 = !eDinV1;
                    }
                }
                if (eDinV1)
                    v3[i] = v1[i];
                else
                    v3[i] = v2[i];
                
            }
            for (int i = 0; i < v3.Length; i++)
                Console.Write(v3[i]);
            Console.ReadKey();
        }
    }
}
