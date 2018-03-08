using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscPlus1
{
    class Program
    {
        static int[] x = new int[102];
        static int n = 100;
        static ulong nrafis;
        static void Main(string[] args)
        {

            // 1820
            // n%2 ==0 ; n /=2
            // else    ; n = 3*n+1
            
            
            nrafis = 0;
            back(1);
            Console.WriteLine("done.");
            Console.ReadKey();

        }
        static void back(int k)
        {
            for (int i = 0; i <= 2; i++)
            {
                x[k] = i;
                if (k > 1)
                    if (x[k] * x[k - 1] != 1)
                        if (k == n)
                            afis();
                        else
                            back(k + 1);
                    else;
                else back(k + 1);
            }

        }
        static bool bun(int[] x, int k)
        {
            if (x[0] == 1)
                return false;
            if (k > 0)
            {
                if (x[k - 1] == 1 && x[k] == 1)
                    return false;
            }
            return true;
        }

        static void afis()
        {
            nrafis++;

            if (nrafis % 8222000 == 0)
            {
                Console.Clear();
                Console.WriteLine(nrafis + " .) ");

                for (int i = 1; i <= n; i++)
                    Console.Write(x[i]);
                Console.WriteLine();
            }
        }
    }
}
