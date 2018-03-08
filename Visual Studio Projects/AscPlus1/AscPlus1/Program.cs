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
        static int[] x;
        static ulong nrafis;
        static int startCount;

        static void Main(string[] args)
        {

            // 1820
            // n%2 ==0 ; n /=2
            // else    ; n = 3*n+1

            nrafis = 0;

            startCount = 4;

            n = 1820;
            x = new int[n];
            for (int i = 0; i < startCount; i++)
                x[i] = 2;
            back2(startCount);
            //afis();
            Console.WriteLine("\n\n\n----------------------------------");
            Console.WriteLine("             Done.");
            Console.ReadKey();

        }
        static void back2(int k)
        {
            foreach(int i in numerelePosibile)
            {
                x[k] = i;
                if (k >= startCount) if (x[k] * x[k - 1] != 1)
                        if (k == n - 1) {
                            afis();
                            //int q = 2;
                        }
                        else back2(k + 1);
                    else;
                else back2(k + 1);
            }
        }
/*        static void back(int k)
        {
            //printArray();
            Console.WriteLine(k);
            for(int i=1;i<=2;i++)
            {
                if (x.Count <= n)
                    x.Add(i);
                else
                    x[k] = i;

                if (k > startCount) {
                    if (x[k] * x[k - 1] != 1)
                        if (k == n)
                            afis();
                        else
                            back(k + 1);

                }
                else
                    back(k + 1);
            }

        }
  */      
        private static void printArray()
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (i == startCount)
                    Console.Write(".");
                Console.Write(x[i]);
            }
            Console.WriteLine();
        }

        private static int getComplementara(int i)
        {
            if (i == 0)
                return 0;
            return 3 - i;
        }

        static bool potAdauga(int k,int i)
        {
               return (x[k] * i != 1);
        }

        static void afis()
        {
            nrafis++;

           if (nrafis % 80000 == 0)
           {
            //    Console.Clear();
                Console.Write(nrafis + ".) ");

                for (int i = 0; i < x.Length; i++) {
                    Console.Write(x[i]);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
