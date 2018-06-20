using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication72
{
    class Program
    {
        // valoare,greutate
        static List<int[]> obiecte = new List<int[]>()
        {
            new int[] { 1,2 },
            new int[] { 2,2 },
            new int[] { 3,5 },
            new int[] { 10,10 },
            new int[] { 1,100 }
        };
        static List<int[]> rucsac = new List<int[]>();
        static int c;
        static void Main(string[] args)
        {
            c = 16;
            while (c > 0)
            {
                obiecte.Sort(delegate (int[] a, int[] b) { return b[0]-a[0]; });
                if (c < obiecte[0][1])
                    break;
                rucsac.Add(obiecte[0]);
                c -= obiecte[0][1];
                obiecte.RemoveAt(0);
            }

            foreach (int[] item in rucsac)
                Console.WriteLine("Valoare: {0}, Greutate: {1}",item[0],item[1]);

            Console.ReadKey();
        }
    }
}
