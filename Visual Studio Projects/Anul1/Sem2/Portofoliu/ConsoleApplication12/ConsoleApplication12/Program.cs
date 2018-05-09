using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = { -2,0,3,1 };
            int n = v.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int mini = i;
                for (int j = i + 1; j < n; j++)
                    if (v[j] < v[mini])
                        mini = j;

                // Swap the found minimum element with the first element
                int temp = v[mini];
                v[mini] = v[i];
                v[i] = temp;
            }
            for (int i = 0; i < v.Length; i++)
                Console.Write(v[i]+" ");
            Console.ReadKey();
        }
    }
}
