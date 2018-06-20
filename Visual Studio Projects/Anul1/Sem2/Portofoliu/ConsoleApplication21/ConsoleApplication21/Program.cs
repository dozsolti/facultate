using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sum = Multiply2Lists(new List<int> { 9, 0 }, new List<int> { 2 });

            foreach (int item in sum)
                Console.Write(item);
            Console.ReadKey();
        }
        public static List<int> Multiply2Lists(List<int> refA, List<int> refB)
        {
            List<int> a = new List<int>();
            a.AddRange(refA);
            List<int> b = new List<int>();
            b.AddRange(refB);
            List<int> c = new List<int>() { 0 };
            b.Reverse();
            for (int i = 0; i < b.Count; i++)
                c = Add2Lists(c, MultiplyListWithANumber(a, b[i], i));

            return c;
        }
        public static List<int> MultiplyListWithANumber(List<int> a, int n, int nrZeros)
        {
            List<int> b = new List<int>();
            for (int i = 0; i < nrZeros; i++)
                b.Add(0);

            int carry = 0;
            a.Reverse();
            for (int i = 0; i < a.Count; i++)
            {

                int nr = a[i] * n + carry;
                if (nr > 9)
                {
                    carry = nr / 10;
                    nr %= 10;
                }
                else
                    carry = 0;
                b.Add(nr);
            }
            a.Reverse();
            if (carry != 0)
                b.Add(carry);
            b.Reverse();
            return b;
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
