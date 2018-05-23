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
        public bool isNegative;
        public List<int> intreaga = new List<int>();
        public List<int> zecimala = new List<int>();

        public static Floatz FromOneList(List<int> a,int separtorPlace)
        {
            int i = a.Count - separtorPlace;

            List<int> intreaga = new List<int>(), zecimala = new List<int>();
            if (separtorPlace <= 0)
            {
                intreaga.AddRange(a);
                for (int j = 0; j < -separtorPlace; j++)
                    intreaga.Add(0);
                zecimala = new List<int>() { 0 };
            }
            else if (separtorPlace>=a.Count)
            {
                intreaga = new List<int> { 0};
                zecimala = new List<int>();
                for (int j = 0; j < separtorPlace - a.Count; j++)
                    zecimala.Add(0);
                zecimala.AddRange(a);
            }else
            {

                intreaga.AddRange(a.GetRange(0, i));
                zecimala.AddRange(a.GetRange(i, a.Count - i));
            }
            Floatz b = new Floatz(intreaga, zecimala, false);
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
            return new Floatz(this);
        }
        
        public override string ToString()
        {
            string strIntreaga = "";
            string strZecimala = "";
            if (this.isNegative)
                strIntreaga = "-";
            foreach(int nr in this.intreaga)
                strIntreaga += nr.ToString();

            foreach (int nr in this.zecimala)
                strZecimala += nr.ToString();

            return strIntreaga + this.separator + strZecimala;
        }
        public void Print(string prefix="")
        {
            Console.WriteLine(prefix+this.ToString());
        }
    }
}