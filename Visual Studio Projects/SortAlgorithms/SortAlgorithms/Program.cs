using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class Program
    {
        static Random rnd;
        static void Main(string[] args)
        {
            int[] v = new int[] {1,23,32,-2, 6, 5, 4, 3, 2, 1 };
            print("v: ", v);

            //Bubble sort
            v = sortBubble(v);

            //Selection sort
            //v = sortSelection(v);

            //Insertion sort
            //v = sortInsertion(v);

            rnd = new Random();
            //Quick sort
            //v = sortQuick(v);

            print("v: ", v);
            Console.ReadKey();
        }

        private static int[] sortQuick(int[] v)
        {
            //_# choose pivot_
            //swap a[1, rand(1, n)]

            //_# 2-way partition_
            //k = 1
            //for i = 2:n, if a[i] < a[1], swap a[++k, i]
            //swap a[1, k]
            //_→ invariant: a[1..k - 1] < a[k] <= a[k + 1..n]_

            //    _# recursive sorts_
            //sort a[1..k - 1]
            //sort a[k + 1, n]

            //swap(v[0],ref v[rnd.Next(v.Length)]);
            return new int[] { };

        }

        private static int[] sortSelection(int[] v)
        {
            int k;
            for (int i = 0; i < v.Length; i++)
            {
                k = i;
                for (int j=i;j<v.Length;j++)
                {
                    if(v[j]<v[k])
                    {
                        k=j;
                    }
                }
                swap(ref v[i], ref v[k]);
            }
            return v;
        }

        private static int[] sortInsertion(int[] v)
        {
            for(int i=0; i<v.Length;i++)
                for(int k=i; k>0 && v[k] < v[k - 1]; k--) {
                    swap(ref v[k],ref v[k-1]);
                }
            return v;
        }

        private static int[] sortBubble(int[] v)
        {
            for(int i=0;i<v.Length;i++)
                for (int j = i; j < v.Length; j++)
                {
                    if (v[i] > v[j])
                        swap(ref v[i], ref v[j]);
                }
            return v;
        }

        private static void swap(ref int v1,ref int v2)
        {
            int _temp = v1;
            v1 = v2;
            v2 = _temp;
        }

        private static void print(string name, int[] v)
        {
            string str = name;
            for(int i = 0; i < v.Length; i++)
            {
                str += v[i].ToString()+ ' ' ;
            }
            Console.WriteLine(str);
        }
    }
}
