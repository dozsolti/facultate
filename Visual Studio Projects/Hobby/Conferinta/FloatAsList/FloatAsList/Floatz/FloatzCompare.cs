using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public static bool operator <(Floatz refA, Floatz refB)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            if (!a.isNegative && b.isNegative)
                return false;
            if (a.isNegative && !b.isNegative)
                return true;

            if (a.isNegative && b.isNegative)
            {
                // -0.445 > -0.5 => true
                int compIntreaga = Compare2Lists(a.intreaga, b.intreaga, "intreaga");
                if (compIntreaga == 1)
                    return false;
                if (compIntreaga == -1)
                    return true;
                else
                {
                    int compZecimala = Compare2Lists(a.zecimala, b.zecimala, "zecimala");
                    if (compZecimala == 1)
                        return false;
                    if (compZecimala == -1)
                        return true;
                }
            }
            else
            {
                int compIntreaga = Compare2Lists(a.intreaga, b.intreaga, "intreaga");
                if (compIntreaga == 1)
                    return true;
                if (compIntreaga == -1)
                    return false;
                else
                {
                    int compZecimala = Compare2Lists(a.zecimala, b.zecimala, "zecimala");
                    if (compZecimala == 1)
                        return true;
                    if (compZecimala == -1)
                        return false;
                }
            }
            return false;
        }
        public static bool operator >(Floatz refA, Floatz refB)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            if (!a.isNegative && b.isNegative)
                return true;
            if (a.isNegative && !b.isNegative)
                return false;

            if (a.isNegative && b.isNegative)
            {
                // -0.445 > -0.5 => true
                int compIntreaga = Compare2Lists(a.intreaga, b.intreaga, "intreaga");
                if (compIntreaga == 1)
                    return true;
                if (compIntreaga == -1)
                    return false;
                else
                {
                    int compZecimala = Compare2Lists(a.zecimala, b.zecimala, "zecimala");
                    if (compZecimala == 1)
                        return true;
                    if (compZecimala == -1)
                        return false;
                }
            }
            else
            {
                int compIntreaga = Compare2Lists(a.intreaga, b.intreaga, "intreaga");
                if (compIntreaga == 1)
                    return false;
                if (compIntreaga == -1)
                    return true;
                else
                {
                    int compZecimala = Compare2Lists(a.zecimala, b.zecimala, "zecimala");
                    if (compZecimala == 1)
                        return false;
                    if (compZecimala == -1)
                        return true;
                }
            }
            return false;
        }

        public static bool operator ==(Floatz refA, Floatz refB)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            if (a.isNegative != b.isNegative)
                return false;

            int compIntreaga = Compare2Lists(a.intreaga, b.intreaga, "intreaga");
            if (compIntreaga != 0)
                return false;

            int compZecimala = Compare2Lists(a.zecimala, b.zecimala, "zecimala");
            if (compZecimala != 0)
                return false;

            return true;
        }
        public static bool operator !=(Floatz refA, Floatz refB)
        {
            Floatz a = refA.Clone();
            Floatz b = refB.Clone();
            return !(a == b);
        }
        /// <summary>
        ///  -1 => a>b | 0 => a==b |  1 => b>a
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Compare2Lists(List<int> refA, List<int> refB, string partea = "intreaga")
        {
            List<int> a = ComprimaList(refA, partea);
            List<int> b = ComprimaList(refB, partea);
            if (partea == "intreaga")
            {
                
                if (a.Count > b.Count)
                    return -1;
                if (a.Count < b.Count)
                    return 1;

                for (int i = 0; i < a.Count; i++)
                {
                    if (a[i] > b[i])
                        return -1;

                    if (a[i] < b[i])
                        return 1;

                }

                return 0;
            }
            else
            {

                //partea zecimala
                // 0.445 < 0.5
                // 0.4451 > 0.445
                int minLen = Math.Min(a.Count, b.Count);
                for (int i = 0; i < minLen; i++)
                {
                    if (a[i] > b[i])
                        return -1;
                    if (a[i] < b[i])
                        return 1;
                }
                if (a.Count == b.Count)
                    return 0;
                else if (a.Count < b.Count)
                {
                    for (int i = a.Count; i < b.Count; i++)
                        if (b[i]>0)
                            return 1;
                }
                else if (a.Count > b.Count)
                {
                    for (int i = b.Count; i < a.Count; i++)
                        if (a[i] > 0)
                            return -1;
                }
                return 0;
            }
        }
    }
}