using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public static Floatz operator +(Floatz a, Floatz b) => Add(a, b);
        public static Floatz operator ++(Floatz a) { return a + Floatz.Constants.ONE(); }

        public static Floatz operator *(Floatz a, Floatz b) => Multiply(a, b);

        public static Floatz operator -(Floatz a, Floatz b) => Subtract(a, b);
        public static Floatz operator --(Floatz a) { return a - Floatz.Constants.ONE(); }

        public static Floatz operator /(Floatz a, Floatz b) => Divide(a, b);

        public static Floatz Add(Floatz refA, Floatz refB)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            Floatz c = new Floatz(a.separator);
            c.isNegative = false;

            if (a.isZero() && b.isZero())
            {
                return Floatz.Constants.ZERO(a.separator);
            }
            if (a.isZero())
            {
                return b;
            }
            if (b.isZero())
            {
                return a;
            }
            #region In caz ca trebuie substrase
            if (a.isNegative && !b.isNegative)
            {
                //-a + b => b-a
                //-3 + 5 = 5-3 = 2
                return Subtract(b, a);
            }
            if (!a.isNegative && b.isNegative)
            {
                //a + (-b)=> a-b
                //5 + -3 = 2
                return Subtract(a, b);
            }
            if (a.isNegative && b.isNegative)
            {
                //-a + -b=> -(a+b)
                //-5 + -3 = -(5+3)=-8
                c.isNegative = true;
            }
            #endregion

            c.zecimala = Add2Lists(a.zecimala, b.zecimala, "zecimala");
            c.intreaga = Add2Lists(a.intreaga, b.intreaga, "intreaga");

            if (c.zecimala.Count > Math.Max(a.zecimala.Count, b.zecimala.Count))
            {
                c.intreaga = Add2Lists(c.intreaga, new List<int> { 1 });
                c.zecimala.RemoveAt(0);
            }

            c.ComprimaZecimala();

            return c;
        }
        public static List<int> Add2Lists(List<int> refA, List<int> refB, string partea = "intreaga")
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
            if (partea == "zecimala")
            {
                for (int i = a.Count; i < b.Count; i++)
                    a.Add(0);
            }
            a.Reverse();
            b.Reverse();
            //Console.WriteLine("{0}+{1}",Floatz.ListToString(a), Floatz.ListToString(b));
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

        public static Floatz Subtract(Floatz refA, Floatz refB)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            Floatz c = new Floatz(a.separator);
            if (a.isZero() && b.isZero())
            {
                return Floatz.Constants.ZERO(a.separator);
            }
            if (a.isZero())
            {
                c.intreaga = b.intreaga;
                c.zecimala = b.zecimala;
                c.isNegative = !b.isNegative;
                return c;
            }
            if (b.isZero())
            {
                c.intreaga = a.intreaga;
                c.zecimala = a.zecimala;
                c.isNegative = a.isNegative;
                return c;
            }
            //Console.WriteLine("{0}|{1}",Floatz.ListToString(a.intreaga), Floatz.ListToString(a.zecimala));
            /*
             * 5-3
             * if(5<3)
             *  return -(5-3)
             * else
             *  return 5-3
             */

            if (!a.isNegative && b.isNegative)
            {
                b.isNegative = false;
                c = Add(a, b);
                return c;
            }
            if (a.isNegative && !b.isNegative)
            {
                a.isNegative = false;
                c = Add(a, b);
                c.isNegative = true;
                return c;
            }
            if (a < b)
            {
                c = Subtract(b, a);
                c.isNegative = true;
                return c;
            }

            // Aceasta functie este construita in asa fel incat a > b
            List<int> fullA = a.ToOneList();
            if (a.isZecimalaZero())
                fullA.Add(0);

            List<int> fullB = b.ToOneList();
            if (b.isZecimalaZero())
                fullB.Add(0);

            for (int i = 0; i < a.intreaga.Count - b.intreaga.Count; i++)
                fullB.Insert(0, 0);
            for (int i = 0; i < b.intreaga.Count - a.intreaga.Count; i++)
                fullA.Insert(0, 0);
            for (int i = 0; i < a.zecimala.Count - b.zecimala.Count; i++)
                fullB.Add(0);
            for (int i = 0; i < b.zecimala.Count - a.zecimala.Count; i++)
                fullA.Add(0);


            List<int> fullC = Subtract2Lists(fullA, fullB);
            int fullCi = 0;
            fullCi = Math.Max(a.zecimala.Count, b.zecimala.Count);

            c = Floatz.FromOneList(fullC, fullCi);
            c.ComprimaIntreaga();
            c.ComprimaZecimala();
            return c;
        }
        public static List<int> Subtract2Lists(List<int> refA, List<int> refB)
        {
            List<int> a = new List<int>();
            a.AddRange(refA);
            List<int> b = new List<int>();
            b.AddRange(refB);
            List<int> c = new List<int>();
            a.Reverse();
            b.Reverse();
            //a va fii lista cu cele mai multe numere
            if (a.Count < b.Count)
            {
                List<int> temp = a;
                a = b;
                b = temp;
            }
            int carry = 0;
            for (int i = 0; i < b.Count; i++)
            {
                int nr = a[i] - b[i] - carry;
                if (nr < 0)
                {
                    carry = 1;
                    nr += 10;
                }
                else
                    carry = 0;
                c.Add(nr);
            }


            for (int i = b.Count; i < a.Count; i++)
            {
                c.Add(a[i] - carry);
                carry = 0;
            }


            c.Reverse();
            c = Floatz.ComprimaList(c);
            return c;
        }

        public static Floatz Multiply(Floatz refA, Floatz refB)
        {

            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            if (a.isZero() || b.isZero())
                return Floatz.Constants.ZERO(a.separator);

            List<int> fullA = a.ToOneList();
            List<int> fullB = b.ToOneList();
            List<int> fullC;
            if (a.zecimala.Count >= b.zecimala.Count)
                fullC = Multiply2Lists(fullA, fullB);
            else
                fullC = Multiply2Lists(fullB, fullA);

            int sepPlace = 0;
            if (!a.isZecimalaZero())
                sepPlace += a.zecimala.Count;
            if (!b.isZecimalaZero())
                sepPlace += b.zecimala.Count;

            Floatz c = new Floatz(a.separator);

            c = Floatz.FromOneList(fullC, sepPlace);
            c.isNegative = (a.isNegative || b.isNegative);
            if (a.isNegative && b.isNegative)
                c.isNegative = false; //-1*-1=1

            c.ComprimaIntreaga();
            c.ComprimaZecimala();

            return c;

        }
        public static List<int> Multiply2Lists(List<int> refA, List<int> refB)
        {
            //a este mai lung decat b
            List<int> a = new List<int>();
            a.AddRange(refA);
            List<int> b = new List<int>();
            b.AddRange(refB);
            List<int> c = new List<int>() { 0 };
            b.Reverse();
            for (int i = 0; i < b.Count; i++)
            {
                c = Add2Lists(c, MultiplyListWithANumber(a, b[i], i));
            }

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

        public static Floatz Divide(Floatz refA, Floatz refB, long nrMaxZecimalaLaImpartire = 74)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            if (a.isZero())
                return new Floatz(a.separator);
            if (b.isZero())
                throw new Exception("a/0");
            if (a == b)
                return Floatz.Constants.ONE(a.separator);

            List<int> fullB = b.ToOneList();
            if (!b.isZecimalaZero())
            {
                string mult = "1";
                for (int i = 0; i < b.zecimala.Count; i++)
                    mult += "0";

                a = a * new Floatz(mult);
            }

            //a.Print();
            //Console.WriteLine(Floatz.ListToString(fullB));
            Floatz c = new Floatz();
            c = DivideFloatzWithList(a, fullB, nrMaxZecimalaLaImpartire);
            //c.Print();

            c.separator = a.separator;
            c.isNegative = (a.isNegative || b.isNegative);
            if (a.isNegative && b.isNegative)
                c.isNegative = false; //-1*-1=1

            return c;
        }
        public static Floatz DivideFloatzWithList(Floatz a, List<int> b, long nrMaxZecimalaLaImpartire, bool debugMode = false)
        {
            Floatz c = new Floatz();
            List<int> temp = new List<int>();
            int cmp = 0;
            for (int i = 0; i < a.intreaga.Count; i++)
            {
                temp.Add(a.intreaga[i]);
                cmp = Compare2Lists(temp, b);
                if (cmp < 1)//317/51 || 317 || 51
                {
                    List<int> deCateOriIntra = DeCateOriIntra(b, temp);
                    List<int> sub = Floatz.Multiply2Lists(deCateOriIntra, b);
                    if (debugMode)
                        Console.WriteLine(Floatz.ListToString(temp) + "/" + Floatz.ListToString(b) + "=" + Floatz.ListToString(deCateOriIntra));

                    c.intreaga.AddRange(deCateOriIntra);
                    if (debugMode)
                        Console.Write(Floatz.ListToString(temp) + "-" + Floatz.ListToString(sub) + "=");
                    temp = Floatz.Subtract2Lists(temp, sub);
                    if (debugMode)
                    {

                        Console.Write(Floatz.ListToString(temp));
                        Console.WriteLine();
                    }

                    if (Floatz.ListIsZero(temp))
                        break;
                }
                else
                {
                    c.intreaga.Add(0);
                }
            }
            c.ComprimaIntreaga();
            if (nrMaxZecimalaLaImpartire == 0)
                return c;
            c.zecimala.Clear();
            if (Floatz.ListIsZero(temp))
                temp.Clear();
            if (debugMode)
                Console.WriteLine(",");

            for (int i = 0; i < a.zecimala.Count && nrMaxZecimalaLaImpartire >= 0; i++)
            {

                temp.Add(a.zecimala[i]);

                cmp = Compare2Lists(temp, b);
                if (cmp < 1)
                {
                    List<int> deCateOriIntra = DeCateOriIntra(b, temp);
                    List<int> sub = Floatz.Multiply2Lists(deCateOriIntra, b);
                    if (debugMode)
                        Console.WriteLine(Floatz.ListToString(temp) + "/" + Floatz.ListToString(b) + "=" + Floatz.ListToString(deCateOriIntra));

                    c.zecimala.AddRange(deCateOriIntra.GetRange(0, Math.Min(deCateOriIntra.Count, (int)nrMaxZecimalaLaImpartire)));
                    nrMaxZecimalaLaImpartire -= Math.Min(deCateOriIntra.Count, (int)nrMaxZecimalaLaImpartire);
                    if (debugMode)
                    {
                        Console.WriteLine("nrMaxZecimalaLaImpartire:" + nrMaxZecimalaLaImpartire);
                        Console.Write(Floatz.ListToString(temp) + "-" + Floatz.ListToString(sub) + "=");
                    }

                    temp = Floatz.Subtract2Lists(temp, sub);
                    cmp = Compare2Lists(temp, b);
                    if (cmp == 1)
                        temp.Add(0);
                    if (debugMode)
                    {
                        Console.Write(Floatz.ListToString(temp));
                        Console.WriteLine();
                    }
                }
                else
                {
                    c.zecimala.Add(0);
                    nrMaxZecimalaLaImpartire--;

                }
            }
            if (!Floatz.ListIsZero(temp))
            {
                if (debugMode)
                    Console.WriteLine("---start restu---");
                if (nrMaxZecimalaLaImpartire > 0)
                {
                    if (cmp == 1)
                        temp.Add(0);
                    while (nrMaxZecimalaLaImpartire >= 0)//for (long i = nrMaxZecimalaLaImpartire; i >= 0; i--)
                    {
                        if (debugMode)
                            Console.WriteLine(Floatz.ListToString(temp));
                        cmp = Compare2Lists(temp, b);
                        if (debugMode)
                            Console.WriteLine(Floatz.ListToString(temp) + "?" + Floatz.ListToString(b) + "=" + cmp);
                        if (cmp < 1)
                        {
                            List<int> deCateOriIntra = DeCateOriIntra(b, temp);
                            List<int> sub = Floatz.Multiply2Lists(deCateOriIntra, b);
                            if (debugMode)
                                Console.WriteLine(Floatz.ListToString(temp) + "/" + Floatz.ListToString(b) + "=" + Floatz.ListToString(deCateOriIntra));

                            c.zecimala.AddRange(deCateOriIntra.GetRange(0, Math.Min(deCateOriIntra.Count, (int)nrMaxZecimalaLaImpartire)));
                            nrMaxZecimalaLaImpartire -= Math.Min(deCateOriIntra.Count, (int)nrMaxZecimalaLaImpartire);
                            if (nrMaxZecimalaLaImpartire == 0)
                                break;
                            if (debugMode)
                                Console.Write(Floatz.ListToString(temp) + "-" + Floatz.ListToString(sub) + "=");
                            temp = Floatz.Subtract2Lists(temp, sub);
                            cmp = Compare2Lists(temp, b);
                            if (cmp == 1)
                                temp.Add(0);
                            if (debugMode)
                            {
                                Console.Write(Floatz.ListToString(temp));
                                Console.WriteLine();
                            }
                            if (Floatz.ListIsZero(temp))
                                break;
                        }
                        else
                        {
                            if (debugMode)
                                Console.WriteLine("0 was added.");
                            c.zecimala.Add(0);
                            temp.Add(0);
                            nrMaxZecimalaLaImpartire--;
                        }
                    }
                }
            }
            if (debugMode)
                Console.WriteLine(".");
            c.ComprimaZecimala();
            return c;
        }

        public static List<int> DeCateOriIntra(List<int> b, List<int> temp)
        {
            if (Floatz.ListIsZero(temp))
                return new List<int> { 0 };
            temp = Floatz.ComprimaList(temp, "intreaga");
            if (Floatz.Compare2Lists(temp, b) == 1)
                return new List<int> { 0 };
            if (Floatz.Compare2Lists(temp, b) == 0)
                return new List<int> { 1 };


            List<int> _b = new List<int>();
            foreach (int item in b)
                _b.Add(item);

            List<int> i = new List<int> { 0 };
            int cmp = Floatz.Compare2Lists(temp, _b);
            while (cmp == -1)
            {
                i = Floatz.Add2Lists(i, new List<int> { 1 });
                _b.Clear();
                _b = Floatz.Multiply2Lists(b, i);
                cmp = Floatz.Compare2Lists(temp, _b);
            }
            if (cmp != 0)
                i = Floatz.Subtract2Lists(i, new List<int> { 1 });
            i = ComprimaList(i);
            return i;
        }
        public static List<int> ComprimaList(List<int> refA, string partea = "intreaga")
        {
            List<int> a = new List<int>();
            a.AddRange(refA);
            if (a.Count < 1)
                return new List<int> { 0 };
            if (partea == "intreaga")
            {
                if (a.Count == 1 && a[0] == 0)
                    return a;
                if (a[0] != 0)
                    return a;

                int i = 1;
                while (a[i] == 0 && i < a.Count - 1)
                {
                    i++;
                }
                a.RemoveRange(0, i);
                if (a.Count == 0)
                    return new List<int> { 0 };
            }
            else
            {

                if (a[a.Count - 1] != 0)
                    return a;

                int i = a.Count - 1;
                while (a[i] == 0 && i > 0)
                {
                    a.RemoveAt(i);
                    i--;
                }

                if (a.Count == 0)
                    return new List<int> { 0 };// in caz ca este  0,0,0,0,0
            }
            return a;
        }

        public static Floatz Pow(Floatz refA, Floatz refB)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            if (a.isZero())
                return Floatz.Constants.ZERO(a.separator);
            if (a.isOne() || b.isZero())
                return Floatz.Constants.ONE(a.separator);
            if (b.isOne())
                return a;
            /*
             * 1,5
             * ^1 + ^0,5
             */
            Floatz c = Floatz.Constants.ONE();

            if (!b.isIntreagaZero())
            {
                b = b.ToIntreaga();
                c = new Floatz(a);
                b -= Floatz.Constants.ONE();
                while (!b.isZero())
                {
                    c *= a;
                    b -= Floatz.Constants.ONE();
                    //Console.WriteLine("{0}>{1}",b.ToString(),Floatz.Constants.ZERO());
                }
            }
            if (!refB.isZecimalaZero())
            {
                Floatz zec = refB.Clone().ToZecimala();

                Floatz n = (Floatz.Constants.ONE() / zec);
                //Console.WriteLine(zec.ToString());
                //Console.WriteLine(n.ToString());

                Floatz xn = a.Clone();
                Floatz xn1 = xn - (Pow(xn, n) - a) / (n * Pow(xn, (n - Floatz.Constants.ONE())));
                Floatz dif = xn - xn1;
                while (Floatz.Abs(dif) > Floatz.Constants.SqrtTreshold)
                {
                    Floatz powXnNM1 = Pow(xn, (n - Floatz.Constants.ONE()));
                    xn1 = xn - ((powXnNM1 * xn) - a) / (n * powXnNM1);
                    dif = xn - xn1;
                    //Console.WriteLine("xn1: {0}\nxn:{1}",xn1,xn);
                    xn = xn1.Clone();
                }
                c *= xn1;
            }
            return c;
        }
        public static Floatz Abs(Floatz refA)
        {
            Floatz a = new Floatz(refA);
            if (!refA.isNegative)
                a.isNegative = false;
            return a;
        }
    }
}