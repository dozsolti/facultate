using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v1 = { 1, 2, 3,4,5 };
            int[] v2 = { 2,4,5,7 };
            int[] v3 = diferenta(v1, v2);
            for (int i = 0; i < v3.Length; i++)
                Console.Write(v3[i]);
            Console.ReadKey();
        }

        private static int[] diferenta(int[] v1, int[] v2)
        {
            List<int> v3 = new List<int>();
            foreach (int item in v1)
                if (!contine(item, v2))
                    v3.Add(item);
            return v3.ToArray();
        }

        private static bool contine(int v, int[] v2)
        {
            for (int i = 0; i < v2.Length; i++)
                if (v2[i] == v)
                    return true;
            return false;
        }
    }
}
