using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[3];
            int min = v[0], max = v[0];
            foreach (var item in v)
            {
                min = Math.Min(item, min);
                max = Math.Max(item, max);
            }
        }
    }
}
