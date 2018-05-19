using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication43
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1,3,0,4,2,3};
            Console.WriteLine(min(a,0,a.Length-1));
            Console.ReadKey();
        }
        static int min(int[] a,int st,int dr)
        {
            if (st >= dr)
                return a[st];
            else
            {
                int m = (st + dr) / 2;
                int ms = min(a, st, m);
                int md = min(a, m + 1,dr);
                if (ms < md)
                    return ms;
                else
                    return md;
            }
        }
    }
}
