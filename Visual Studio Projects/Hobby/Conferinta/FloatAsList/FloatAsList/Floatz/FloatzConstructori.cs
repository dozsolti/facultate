using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public Floatz(char separator = ',')
        {
            
            this.separator = separator;
            this.intreaga = new List<int> { 0 };
            this.zecimala = new List<int> { 0 };
        }

        public Floatz(string n, char separator = ',')
        {
            // ex. new Floatz("3.14",'.');
            // ex. new Floatz("3,14",',');
            this.isNegativ = false;
            if (n[0] == '-')
            {
                this.isNegativ = true;
                n = n.Remove(0,1);
            }
            this.separator = separator;
            string[] secvente = n.Split(this.separator);

            string intreaga = secvente[0];
            foreach (char nr in intreaga)
                this.intreaga.Add(charToInt(nr));

            if (secvente.Length == 1)
            {
                // ex. new Floatz("9");
                this.zecimala = new List<int> { 0 };
                return;
            }

            string zecimala = secvente[1];
            foreach (char nr in zecimala)
                this.zecimala.Add(charToInt(nr));
            this.ComprimaZecimala();
        }

        public Floatz(int n, char separator = ',') : this(n.ToString(), separator){}
        public Floatz(float n, char separator = ',') : this(n.ToString(), separator) { }
        public Floatz(double n, char separator = ',') : this(n.ToString(), separator) { }
        public Floatz(decimal n, char separator = ',') : this(n.ToString(), separator) { }

        public Floatz(object i, object z = null,bool isNegativ=false,char separator=',')
        {
            this.separator = separator;

            if (   i is Int16 || i is Int32 || i is Int64
                || i is UInt16 || i is UInt32 || i is UInt64
                || i is SByte || i is Byte || i is String
                || i is short)
            {
                string intreaga = i.ToString();
                if (intreaga[0] == '-')
                {
                    this.isNegativ = true;
                    intreaga = intreaga.Remove(0,1);
                }
                foreach (char nr in intreaga)
                    this.intreaga.Add(charToInt(nr));
            }
            if(isNegativ)
                this.isNegativ = isNegativ;


            if(z == null)
            {
                this.zecimala = new List<int>{0};
                return;
            }

            if (   z is Int16 || z is Int32 || z is Int64 
                || z is UInt16 || z is UInt32 || z is UInt64
                || z is SByte || z is Byte ||z is String
                || z is short)
            {
                string zecimala = z.ToString();
                foreach (char nr in zecimala)
                    this.zecimala.Add(charToInt(nr));
            }
            this.ComprimaZecimala();
        }

        public Floatz(List<int> intreaga, List<int> zecimala = null, bool isNegativ = false, char separator = ',')
        {
            this.separator = separator;
            this.intreaga = intreaga;
            this.isNegativ = isNegativ;
            if (zecimala == null)
                this.zecimala = new List<int>{ 0 };
            else
                this.zecimala = zecimala;
        }

        public Floatz(int[] intreaga, int[] zecimala = null, bool isNegativ = false, char separator = ',')
        {
            this.separator = separator;
            this.isNegativ = isNegativ;

            this.intreaga = intreaga.ToList();
            if (zecimala == null)
                this.zecimala = new List<int> { 0 };
            else
                this.zecimala = zecimala.ToList();
            this.ComprimaZecimala();
        }
    }
}