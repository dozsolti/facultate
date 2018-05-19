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

            //Console.WriteLine(Floatz.Teste.TestInmultire());
            //Console.WriteLine(Floatz.Teste.TestComparari());
            //Console.WriteLine(Floatz.Teste.TestScadere());
            if(Floatz.Teste.TestDeCateOriIntra()!="Nu exista probleme la DeCateOriIntra.")
                Console.WriteLine(Floatz.Teste.TestDeCateOriIntra());
            /*List<int> a = new List<int>() { 1,2,3};
            List<int> i = new List<int> { 0 };
            Console.WriteLine(Floatz.ListToString(Floatz.Add2Lists(a,i)));
            i = Floatz.Add2Lists(i, new List<int> { 1 });
            Console.WriteLine(Floatz.ListToString(Floatz.Add2Lists(a,i)));
            i = Floatz.Add2Lists(i, new List<int> { 1 });
            Console.WriteLine(Floatz.ListToString(Floatz.Add2Lists(a, i)));*/
            //Console.WriteLine(Floatz.ListToString((new Floatz("44").ToOneList())));
            Floatz a = new Floatz("0,21");//("30,623");//30,623
            Floatz b = new Floatz("0,3");
            Floatz c = Floatz.Divide(a, b,10);
            Console.WriteLine("{0}/{1}={2}",a.ToString(),b.ToString(),c.ToString());
            /*Console.WriteLine(
                Floatz.ListToString(
                    Floatz.Subtract2IntreagaLists(new List<int> { 7,5 }, new List<int> { 2, 9 })
                ));*/
            /*Floatz a = new Floatz("3,14159");
            Floatz b = new Floatz(2);
            Floatz c = new Floatz(-rnd.NextDouble());
            Floatz d = new Floatz(3849561.1594519515195615m); 
            Floatz e = new Floatz(new int[] { 1 ,2},new int[] { 8,9 });
            Floatz f = new Floatz("9", 123,true);
            */

            //List<int> sum = new List<int> { 9, 8, 9, 8 };
            // Console.WriteLine(Floatz.ListToString(sum.GetRange(0,sum.Count)));
            //Console.WriteLine(Floatz.ListToString(sum,""));

            //Console.WriteLine(Floatz.Subtract(Floatz.Constants.PI(),Floatz.Constants.E()).ToString());
            /* Floatz a = Floatz.Constants.PI();
             Floatz b = Floatz.Constants.E();*/
            //Console.WriteLine();
            /*Console.WriteLine(
                new Floatz(1.2f).ToString()
                +"+"+
                new Floatz(0.8f).ToString()
                +" = "+
                Floatz.Add(new Floatz(1.2f), new Floatz(0.8f)).ToString());*/

            /*Console.WriteLine("{0} < {1} = {2} ", a.ToString(), b.ToString(), a < b);
            a = Floatz.Constants.ZERO();
            b = Floatz.Constants.ONE();
            Console.WriteLine("{0} < {1} = {2} ", a.ToString(), b.ToString(), a < b);*/

            // a 7000 cif zec a unui nr
            // a 7000 cifra a unei ecuatii
            Console.ReadKey();
        }
    }
}
