using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("Introduceti ax: ");
            double ax = int.Parse(Console.ReadLine());
            Console.Write("Introduceti ay: ");
            double ay = int.Parse(Console.ReadLine());
            Console.Write("Introduceti bx: ");
            double bx = int.Parse(Console.ReadLine());
            Console.Write("Introduceti by: ");
            double by = int.Parse(Console.ReadLine());
            Console.Write("Introduceti cx: ");
            double cx = int.Parse(Console.ReadLine());
            Console.Write("Introduceti cy: ");
            double cy = int.Parse(Console.ReadLine());
            double c = Math.Sqrt(Math.Pow(ax - bx, 2) + Math.Pow(ay - by, 2));
            double a= Math.Sqrt(Math.Pow(bx - cx, 2) + Math.Pow(by - cy, 2));
            double b= Math.Sqrt(Math.Pow(cx - ax, 2) + Math.Pow(cy - ay, 2));
            double p = (a + b + c) / 2;
            double aria = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            if (aria <= 0)
            {
                Console.WriteLine("Nu e triunghi!");
            }
            else
            {
                Console.WriteLine("Aria triunghiului este: {0}", aria);
            }

        }
    }
}
