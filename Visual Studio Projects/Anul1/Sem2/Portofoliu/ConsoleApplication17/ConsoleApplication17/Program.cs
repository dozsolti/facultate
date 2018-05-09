using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17
{
    class Program
    {
        static void Main(string[] args)
        {
            //A,B A-B=A[i]-AnB
            int[] v1 = { 1, 2, 3 };
            int[] v2 = { 1, 5, 3 };
            int[] v3 = intersectie(v1, v2);
            for (int i = 0; i < v3.Length; i++)
            {
                Console.Write(v3[i]);
            }
            Console.ReadKey();
        }

        private static int[] intersectie(int[] v1, int[] v2)
        {
            int len = 0;
            for (int i = 0; i < v1.Length; i++)
                    if (!contine(v1[i],v2))
                        len++;
            for (int i = 0; i < v2.Length; i++)
                if (!contine(v2[i], v1))
                    len++;
            int[] v3 = new int[len];
            int k = 0;
            for (int i = 0; i < v1.Length; i++)
                if (!contine(v1[i], v2))
                {
                    v3[k] = v1[i];
                    k++;
                }
            for (int i = 0; i < v2.Length; i++)
                if (!contine(v2[i], v1))
                {
                    v3[k] = v2[i];
                    k++;
                }
            return v3;
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
