using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FloatAsList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Decimal x = Decimal.Divide(355m, 113m);
            // bvhg Console.WriteLine(x);
            //Floatz.Divide(new Floatz(355), new Floatz(113), 700).Print();

            Console.ReadKey();
            Console.WriteLine("Golden ratio:");
            Floatz d = CalcGoldenRation(200);
            d.Print("Floatz: ");
            Console.WriteLine("Corect: 1,61803398874989484820458683436563811772030917980576286213544862270526046281890244...");
            Console.ReadKey();

            //2^100
            Console.WriteLine("Puterile lui 2:");
            Floatz g = new Floatz(2);
            for(int i=1;i<7000;i++)
            {
                g.Print("2^"+i+":");
                g *= Floatz.Constants.TWO();
            }


            /*
             * Floatz a = new Floatz(3);
            Floatz b = new Floatz(4)* new Floatz(3)* new Floatz(2);
            bool add = true;

            Console.WriteLine("Aproximatia lui Pi:");

            for (int i = 2; i < 60000; i++)
            {
                if (add)
                    a += Floatz.Divide(new Floatz(4), b, 30);
                else
                    a -= Floatz.Divide(new Floatz(4), b, 30);
                add = !add;
                b = new Floatz(2*i) * (new Floatz(2*i+1)) * (new Floatz(2 * i + 2));
            }
            Console.WriteLine("Math.PI: {0}", Math.PI);
            a.Print("Floatz : ");
            Console.WriteLine("     PI: 3,1415926535897932384626433832795...");
            Console.ReadKey();*/

            Console.ReadKey();
        }

        private static Floatz CalcGoldenRation(int i)
        {
            if (i == 0)
                return Floatz.Constants.ONE();
            return Floatz.Constants.ONE() 
                + Floatz.Divide(
                    Floatz.Constants.ONE(),
                    CalcGoldenRation(i - 1),
                80);
        }
        
    }
}
