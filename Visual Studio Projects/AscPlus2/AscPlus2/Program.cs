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
            Start();

            back();

            Finished();

        }
        

        private static void back()
        {
            printStatus();
            // check numberFromV
            while (n.ToString().Length != 15)
            {
                updateV();
                recalcN();

                nrTestat++;
                if (nrTestat % 3000 == 0)
                {
                    printStatus();
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
            auxv = VecOp.Add(auxv, new int[] { 2 });
            for(int i=0; i < auxv.Length; i++)
            {
                if (auxv[i] == 1)
                {
                    v[i] = getComplementara(v[i]);
                }
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
