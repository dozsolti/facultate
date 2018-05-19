using System;
using System.Collections.Generic;
using System.Linq;

namespace FloatAsList
{
    public partial class Floatz
    {
        public void ComprimaIntreaga()
        {
            // scoate 0-urile de la final
            // valoarea minima a unui rezultat este 0
            if (this.intreaga.Count == 1 && this.intreaga[0] == 0)
                return;
            if (this.intreaga.Count < 1)
            {
                this.intreaga = new List<int> { 0 };
                return;
            }
            
            if (this.intreaga[0] != 0)
                return;

            
            int i = 1;
            while (this.intreaga[i] == 0 && i < this.intreaga.Count-1)
                i++;
            
            this.intreaga.RemoveRange(0, i);
            if (this.intreaga.Count == 0)
                this.intreaga = new List<int> { 0 };

        }
        public void ComprimaZecimala()
        {
            // scoate 0-urile de la final
            // valoarea minima a unui rezultat este 0
            if (this.zecimala.Count < 1)
            {
                this.zecimala = new List<int> { 0 };
                return;
            }
            if (this.zecimala[this.zecimala.Count - 1] != 0)
                return;

            int i = this.zecimala.Count - 1;
            while (this.zecimala[i] == 0 && i > 0)
            {
                this.zecimala.RemoveAt(i);
                i--;
            }

            if (this.zecimala.Count == 0)
                this.zecimala = new List<int> { 0 };// in caz ca este  0,0,0,0,0

        }

        public static string ListToString(List<int> a, string sep = "")
        {
            if (a.Count == 0)
                return "";
            string str = "";
            foreach (int nr in a)
                str += sep + nr.ToString();
            if (sep != "")
                str = str.Remove(0, 1);
            return str;
        }

        public static int charToInt(char a)
        {
            return a - '0';
        }

        public static void PrintList(List<int> a,string prefix="")
        {
            Console.WriteLine(prefix+Floatz.ListToString(a));
        }
       
    }
}