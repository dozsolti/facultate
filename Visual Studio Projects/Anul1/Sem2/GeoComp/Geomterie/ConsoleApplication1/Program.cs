using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program

    {
        static int a1, a2, a3, b1, b2, b3;
        public static void citire()
        {
            Console.Write("Introduceti a1:");
             a1 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti a2:");
           a2 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti a3:");
             a3 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti b1:");
             b1 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti b2:");
             b2 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti b3:");
             b3 = int.Parse(Console.ReadLine());
        }

        public static void SVMV()
        {
           
            Console.WriteLine("Produsul scalar al celor 2 este:{0}", a1 * b1 + a2 * b2 + a3 * b3);
            Console.WriteLine("Produsul vectorial este: i*({0})-j*({1})+k*({2})", a2 * b3 - a3 * b2, a1 * b3 - a3 * b1, a1 * b2 - a2 * b1);
            Console.WriteLine("Norma vectorului este:{0}", Math.Sqrt(Math.Pow(a1 - b1, 2) + Math.Pow(a2 - b2, 2) + Math.Pow(a3 - b3, 2)));


        }

        public static void volumParalelipiped()
        {
            Console.Write("Introduceti c1:");
            int c1 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti c2:");
            int c2 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti c3:");
            int c3 = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Abs((b2 * c3 - b3 * c2) * a1 +(b1 *c3 - b3 * c1) * a2 + (b1 * c2 - b2 * c1) * a3));


        }

        public static void distPctDreapta()
        {
            Console.WriteLine("ax+by+c");
            Console.Write("Introduceti a:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Introduceti b:");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Introduceti c:");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti x,y");
            Console.Write("Introduceti x:");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Introduceti y:");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Distanta intre puct si dreapta este:{0}", Math.Abs(a * x + b * y + c) / Math.Sqrt(a * a + b * b));

        }

        public static void dreapta()
        {
            Console.Write("Introduceti x1:");
            int x1 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti y1:");
            int y1 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti x2:");
            int x2 = int.Parse(Console.ReadLine());
            Console.Write("Introduceti y2:");
            int y2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Ecuatia dreptei este:x*({0})-y*({1})+{2}",y2-y1,x2-x1,-x1*(y2-y1)+y1*(x2-x1));
        }
        static void Main(string[] args)
        {
            citire();
            volumParalelipiped();
        }
    }
}
