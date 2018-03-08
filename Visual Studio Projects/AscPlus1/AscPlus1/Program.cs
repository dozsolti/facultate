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
        static ulong nFromArray;
        static int[] x;
        static ulong nrafis;
        static int nrMaxDeDoi;
        static int startCount;

        static int maxLen;
        static int iForNumber;
        static ulong _temp;
        static void Main(string[] args)
        {

            Console.WriteLine("             Loading please wait...");
            Console.WriteLine("------------| "+(System.DateTime.Now.ToString())+" |------------");

            // 1820
            // n%2 ==0 ; n /=2
            // else    ; n = 3*n+1
            maxLen = 0;
            nrafis = 0;
            nrMaxDeDoi = 10;

            startCount = 4;

            n = 1820;
            x = new int[n];
            for (int i = 0; i < startCount; i++)
                x[i] = 2;
            back2(startCount);
            
            Console.WriteLine("\n\n\n----------------------------------");
            Console.WriteLine("             Done.");
            Console.ReadKey();

        }
        static void back2(int k)
        {
            foreach (int i in numerelePosibile)
            {

                    x[k] = i;

                if (k >= startCount)
                {
                    if (eBun(k))
                    {
                        
                            if (k == n - 1)
                                afis();
                            else
                                back2(k + 1);
                    }
                }
                else
                    back2(k + 1);
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
                Console.Write(x[i]);
            }
        }

        private static int getComplementara(int i)
        {
            if (i == 0)
                return 0;
            return 3 - i;
        }

        static bool eBun(int k)
        {
            if (x[k] * x[k - 1] == 1) //doi de 1 sa nu fie unul langa altul
                return false;
            if (k > nrMaxDeDoi) //numarul maxim de 2 de la inceput
            {
                bool areDoarDoi = true;
                for (int i = 0; i <= nrMaxDeDoi; i++)
                {
                    if (x[i] != 2)
                    {
                        areDoarDoi = false;
                        break;
                    }
                }
                if(areDoarDoi)
                    return false;
            }

            
            /*if ( (k>4) && (x[k] * x[k - 1] * x[k - 2] == 2*2*2)) //doi de 1 sa nu fie unul langa altul
                return false;
                */
            return true;
        }

        static void afis()
        {
           nrafis++;
            nFromArray = arrayToNumber(x);
            int len = nFromArray.ToString().Length;
            if (nrafis % 16000000 == 0)
            {
                if(maxLen< len)
                    maxLen = len;
                Console.WriteLine(nFromArray);
            }
           {
                if (len == 15)
                {
                    //    Console.Clear();
                    Console.Write(nrafis + ".) ");

                    printArray();
                
                    Console.WriteLine("Aaaaaaaaaammmmmmmmmmmmm gasssssssssssssittttttttttttttttt numaaaaaaarrruuuuuuuuuuuuuuuullllll!!!! :"+ nFromArray);
                    //Console.WriteLine(nFromArray);
                    Console.WriteLine();
                }
            }
        }

        private static ulong arrayToNumber(int[] array)
        {
            iForNumber = 0;
            _temp = 1;
            while(iForNumber < array.Length)
            {
                if (array[iForNumber] == 1)
                    if ((_temp - 1) % 3 == 0)
                        _temp = (_temp - 1) / 3;
                    else
                        return 0;
                else
                    _temp = _temp * 2;
                iForNumber++;
            }
            return _temp;
        }
    }
}
