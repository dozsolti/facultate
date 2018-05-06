using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public bool eNegativ;
        public List<int> intreaga = new List<int>();
        public List<int> zecimala = new List<int>();

        public override string ToString()
        {
            string strIntreaga = "";
            string strZecimala = "";
            if (this.eNegativ)
                strIntreaga = "-";
            foreach(int nr in this.intreaga)
                strIntreaga += nr.ToString();

            foreach (int nr in this.zecimala)
                strZecimala += nr.ToString();

            return strIntreaga + this.separator + strZecimala;
        }

        int charToInt(char a)
        {
            return a - '0';
        }
    }
}