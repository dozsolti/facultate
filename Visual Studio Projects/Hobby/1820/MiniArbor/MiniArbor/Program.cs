using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniArbor
{
    class Program
    {
        static void Main(string[] args)
        {
            extend(16,4);
            Console.WriteLine("Done.");
            Console.ReadKey();
            Console.ReadKey();
        }

        private static void extend(ulong v, int p)
        {
            if(~(v - 1) == 0 && p<=1760)
            if (v < 16 && p>4)
                return;
            if (p > 1825)
                return;

            if(p==1820 && v.ToString().Length==15)
                if(testIt(v))
                Console.WriteLine(v +" "+p);

            if((v-1)%3==0)
                extend((v - 1) / 3, p + 1);
            extend(v * 2,p+1);
        }

        private static bool testIt(ulong i)
        {
                int p = 0;
                ulong n = i;
                do
                {
                    p++;
                    if (p <= 1770 && ~(n - 1) == 0) return false ;
                    else
                    {
                        if (n % 2 == 0) n = n / 2;
                        else n = n * 3 + 1;
                    }
                } while (n != 1);
                if (p == 1820)
                {
                    Console.Write("{0} -> {1}", i, p);
                    return true;
                }
            return false;
        }
    }
}
