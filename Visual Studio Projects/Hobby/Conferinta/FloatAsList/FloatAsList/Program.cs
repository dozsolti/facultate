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
            Random rnd = new Random();

            Floatz.Teste.RunAllTests();
            //((Floatz.Constants.TWO() + new Floatz("1,5"))/ Floatz.Constants.TWO()).Print();
            Console.WriteLine(Floatz.Sqrt(Floatz.Constants.TWO()));
            // a 7000 cif zec a unui nr
            // a 7000 cifra a unei ecuatii
            Console.ReadKey();
        }
    }
}
