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
        public bool isOne()
        {
            if (!this.isZecimalaZero())
                return false;

            return (this.intreaga.Count==1 && this.intreaga[0]==1);
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
        public Floatz ToIntreaga()
        {
            Floatz a = new Floatz();
            a.intreaga.Clear();
            a.intreaga.AddRange(this.intreaga);
            return a;
        }
        public Floatz ToZecimala()
        {
            Floatz a = new Floatz();
            a.zecimala.Clear();
            a.zecimala.AddRange(this.zecimala);
            return a;
        }
    }
}