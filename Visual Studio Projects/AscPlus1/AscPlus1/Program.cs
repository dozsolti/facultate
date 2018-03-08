using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscPlus1
{
    class Program
    {
        static int[] numerelePosibile =  { 1, 2 };
        static int n ;
        static List<int> x = new List<int>();
        static ulong nrafis;
        static int startCount;

        static void Main(string[] args)
        {

            // 1820
            // n%2 ==0 ; n /=2
            // else    ; n = 3*n+1

            nrafis = 0;
            startCount = 3;

            n = 5;
            n += startCount-1;

            resetArray();
            back(startCount);
            Console.WriteLine("\n\n\n----------------------------------");
            Console.WriteLine("             Done.");
            Console.ReadKey();

        }
        static void back(int k)
        {
            foreach (var i in numerelePosibile)
            {
                if (x.Count <= n)
                    x.Add(i);
                else
                    x[k] = i;
                if (k >= startCount) if (x[k] * x[k - 1] != 1)
                        if (k == n) afis();
                        else back(k + 1);
                    else;
                else back(k + 1);
            }

        }

        private static int getComplementara(int i)
        {
            if (i == 0)
                return 0;
            return 3 - i;
        }

        private static void resetArray()
        {
            x.Clear();
            for (int i = 0; i < startCount; i++)
                x.Add(2);
        }

        static bool potAdauga(int k,int i)
        {
               return (x[k] * i != 1);
        }

        static void afis()
        {
            nrafis++;

            //if (nrafis % 80 == 0)
            {
              //  Console.Clear();
                Console.Write(nrafis + ".) ");

                for (int i = 0; i < x.Count; i++) {
                    if (i==startCount)
                        Console.Write(".");
                    Console.Write(x[i]);
                }
                Console.WriteLine();
            }
            
        }
    }
}
