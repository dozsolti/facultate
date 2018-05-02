using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[] { 1, 23, 32, -2, 6, 5, 4, 3, 2, 1 };

            int k, _temp;
            for (int i = 0; i < v.Length; i++)
            {
                k = i;
                for (int j = i; j < v.Length; j++)
                {
                    if (v[j] < v[k])
                    {
                        k = j;
                    }
                }
                _temp = v[i];
                v[i] = v[k];
                v[k] = _temp;
            }
            for(int i=0;i<v.Length;i++)
                Console.Write(v[i]+" ");
            Console.ReadKey();
        }
    }
}
