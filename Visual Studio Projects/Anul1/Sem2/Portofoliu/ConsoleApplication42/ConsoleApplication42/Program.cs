using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication42
{
    class Program
    {
        static int partition(int[] v, int st,int dr)
        {
            int pivot = v[dr],i = (st - 1);
            for (int j = st; j < dr; j++)
            {
                if (v[j] <= pivot)
                {
                    i++;

                    int temp = v[i];
                    v[i] = v[j];
                    v[j] = temp;
                }
            }

            int temp1 = v[i + 1];
            v[i + 1] = v[dr];
            v[dr] = temp1;

            return i + 1;
        }
        static void quickSort(int[] v, int st, int dr)
        {
            if (st < dr)
            {
                int pi = partition(v, st, dr);

                quickSort(v, st, pi - 1);
                quickSort(v, pi + 1, dr);
            }
        }

        static void printArray(int[] v)
        {
            for (int i = 0; i < v.Length; ++i)
                Console.Write(v[i] + " ");

            Console.WriteLine();
        }

        public static void Main()
        {
            int n = 4;
            int[] arr = {5,2,3,1};
            quickSort(arr, 0, n - 1);
            printArray(arr);
            Console.ReadKey();
        }
    }
}
