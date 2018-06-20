using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication20
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sum = Add2Lists(new List<int> { 9, 9 }, new List<int> { 2 });

            foreach (int item in sum)
                Console.Write(item);
            Console.ReadKey();
        }
        public static List<int> Add2Lists(List<int> refA, List<int> refB)
        {
            List<int> a = new List<int>();
            a.AddRange(refA);
            List<int> b = new List<int>();
            b.AddRange(refB);
            List<int> c = new List<int>();

            //b va fii lista cu cele mai multe numere
            if (a.Count > b.Count)
            {
                List<int> temp = a;
                a = b;
                b = temp;
            }
            a.Reverse();
            b.Reverse();
            int carry = 0;
            for (int i = 0; i < a.Count; i++)
            {
                int nr = a[i] + b[i] + carry;
                if (nr > 9)
                {
                    carry = nr / 10;
                    nr %= 10;
                }
                else
                    carry = 0;
                c.Add(nr);
            }
            for (int i = a.Count; i < b.Count; i++)
            {

                int nr = b[i] + carry;
                if (nr > 9)
                {
                    carry = nr / 10;
                    nr %= 10;
                }
                else
                    carry = 0;
                c.Add(nr);
            }


            if (carry > 0)
                c.Add(carry);

            c.Reverse();
            return c;
        }

    }
}
