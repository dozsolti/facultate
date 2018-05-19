using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public static implicit operator float(Floatz x)
        {
            return -1;
        }

        public static implicit operator int(Floatz x)
        {
            return -1;
        }

        public bool isZero()
        {
            return (this.isIntreagaZero() && this.isZecimalaZero());
        }
        public bool isIntreagaZero()
        {
            for (int i= 0; i < this.intreaga.Count; i++)
                if (this.intreaga[i] != 0)
                    return false;
            return true;
        }
        public bool isZecimalaZero()
        {
            for (int i = 0; i < this.zecimala.Count; i++)
                if (this.zecimala[i] != 0)
                    return false;
            return true;
        }
        public static bool ListIsZero(List<int> a)
        {
            for (int i = 0; i < a.Count; i++)
                if (a[i] != 0)
                    return false;
            return true;
        }
    }
}