using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatiiCuDecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            for (decimal ha = 1; ha > 0.5m; ha -= 0.0000000001m)
            {
                for (decimal hb = 0.5m; hb <= 1m; hb += 0.0000000001m)
                {
                    decimal left = Decimal.Add(Decimal.Multiply(3.489315413474426m,ha), Decimal.Multiply(2.1686170594885876m, hb));
                    decimal right = 5.656178058982471m;
                    if (Decimal.Compare(left, right) == 0)
                        Console.WriteLine("ha: {0} | hb: {1}",ha,hb);
                }
            }

            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
