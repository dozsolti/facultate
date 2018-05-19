using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        /*Construirea unui tip abstract de date cu precizie virtual nelimitata
        S1.) Introducere
        S2.) Dezvoltarea aplicatiei la nivel de P.O.O.
        S3.) Concepte folosite
        S4.) Rezultate si concluzii
        */
        public bool isNegativ;
        public List<int> intreaga = new List<int>();
        public List<int> zecimala = new List<int>();

        public static Floatz FromOneList(List<int> a,int separtorPlace)
        {
            int i = a.Count - separtorPlace;
            Floatz b = new Floatz(
                a.GetRange(0, i),
                a.GetRange(i, a.Count- i)
            );
            return b;
        }
        public List<int> ToOneList()
        {
            List<int> full = new List<int>();
            full.AddRange(this.intreaga);
            if(!this.isZecimalaZero())
                full.AddRange(this.zecimala);
            return full;
        }

        public Floatz Clone()
        {
            return new Floatz(this.ToString());
        }
        public override string ToString()
        {
            string strIntreaga = "";
            string strZecimala = "";
            if (this.isNegativ)
                strIntreaga = "-";
            foreach(int nr in this.intreaga)
                strIntreaga += nr.ToString();

            foreach (int nr in this.zecimala)
                strZecimala += nr.ToString();

            return strIntreaga + this.separator + strZecimala;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}