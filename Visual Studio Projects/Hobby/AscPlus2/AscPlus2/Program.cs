using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace AscPlus2
{
    class Program : Global
    {

        static void Main(string[] args)
        {
            int max, oldmax = 0;
            ulong i = 520074808440080;
            //for (ulong i = 520074808440080-5000; i < 520074808440080 + 5000; i++)
            {
                int p = 0;
                ulong n = i;
                do
                {
                    p++;
                    
                        if (n % 2 == 0) n = n / 2;
                        else n = n * 3 + 1;
                    
                } while (n != 1);
                //if (p == 1820)
                {
                    Console.Write("{0} -> {1}", i, p);
                }
                //if (i % 100000 == 0) Console.Write(i + ": " +p+" ");
            }
            Console.ReadKey();
        Console.ReadKey();
            /*Start();

            back();

            Finished();*/

        }
        

        private static void back()
        {
            printStatus();
            // check numberFromV
            while (n.ToString().Length != 15)
            {
                auxv = VecOp.Add(auxv, new int[] { 1 });
                for (int i = 0; i < auxv.Length; i++)
                {
                    if (auxv[i] == 1)
                        v[i] = 3 - v[i];
                }
                recalcN();

                nrTestat++;
                if (nrTestat % 32000000 == 0)
                {
                    printStatus();
                    Console.WriteLine((System.DateTime.Now).ToString());
                }

            }
            Success();
            /*
            if (n == 0)
            {
                updateV();
            }
            else
            {
                if(n.ToString().Length != 15)
                {
                    updateV();
                    back();
                }
                else
                {
                    Success();
                }
            }*/
        }

        

        private static void updateV()
        {
            auxv = VecOp.Add(auxv, new int[] { 1 });
            for(int i = 0; i < auxv.Length; i++)
            {
                if (auxv[i] == 1)
                    v[i] = 3 - v[i];
            }
            
        }

        private static int getComplementara(int i)
        {
            if (i == 0)
                return 0;
            return 3 - i;
        }
    }
}
