using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniciPeSfoara
{
    class Program
    {
        static int[] v;
        static void Main(string[] args)
        {
            v = new int[] { 0,0,0,-1,0,-1,1,0,-1,0,1,-1,0,1,0,-1,1,1,0,0};
            step();
            print();
            Console.ReadKey();
        }

        private static void step()
        {
            for (int i = 0; i < v.Length; i++) {
                if (v[i] == 1)
                {
                    if (i == v.Length - 1)
                        v[v.Length] = 0;
                    swap(ref v[i],ref v[i+1]);
                }
                else if (v[i] == -1)
                {
                    if (i == 0)
                        v[0] = 0;
                    swap(ref v[i], ref v[i - 1]);
                }
            }
        }

        private static void swap(ref int v1,ref int v2)
        {
            int _aux = v1;
            
        }

        private static void print()
        {
            string s = "";
            for (int i = 0; i < v.Length; i++) {
                s += v[i]+" ";
            }
            Console.WriteLine(s);
        }
    }
}
