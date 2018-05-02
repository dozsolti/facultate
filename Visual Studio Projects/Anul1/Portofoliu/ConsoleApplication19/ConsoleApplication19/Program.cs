using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication19
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v1 = { 3,4 };
            int[] v2 = { 1, 2, 3,4,5,6,7,8,9 };
            Console.WriteLine( (contains(v1,v2) ? "" : "Nu") + " contine");
            Console.ReadKey();
        }

        private static bool contains(int[] v1, int[] v2)
        {
            for (int i = 0; i < v2.Length - v1.Length; i++) {
                if (v2[i] == v1[0])
                {
                    for (int j = 1; j < v1.Length; j++)
                    {
                        if (v2[i + j] != v1[j])
                        {
                            break;
                        }
                        if (j == v1.Length - 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
