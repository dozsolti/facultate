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

            Floatz a = new Floatz("-3,14159");
            Floatz b = new Floatz(2);
            Floatz c = new Floatz(-rnd.NextDouble());
            Floatz d = new Floatz(3849561.1594519515195615m); 
            Floatz e = new Floatz(new int[] { 1 ,2},new int[] { 8,9 });
            Floatz f = new Floatz("9", 123,true);
            
            
            Console.WriteLine(Floatz.Constants.E.ToString());

            //Console.WriteLine((float)a);
            //Console.WriteLine("{0} + {1} = {2} ", a.ToString(), b.ToString(), c.ToString());

            Console.ReadKey();
        }
    }
}
