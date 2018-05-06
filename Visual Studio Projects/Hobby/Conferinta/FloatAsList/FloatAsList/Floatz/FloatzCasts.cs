using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public static implicit operator float(Floatz x)
        {
            if (x.intreaga.Count > 7 || x.zecimala.Count > 4)
                return float.Parse(x.numarEroareCasting);

            float n = 0;
            foreach (int nr in x.intreaga)
                n = n * 10 + nr;

            float k = 10;
            foreach (int nr in x.zecimala)
            {
                n += nr / k;
                k *= 10;
            }

            return n;
        }

        public static implicit operator int(Floatz x)
        {
            if (x.intreaga.Count > 7)
                return int.Parse(x.numarEroareCasting);

            int n = 0;
            foreach (int nr in x.intreaga)
                n = n * 10 + nr;
            return n;
        }

    }
}