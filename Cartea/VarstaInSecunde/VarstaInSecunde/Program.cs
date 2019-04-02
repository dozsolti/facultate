using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarstaInSecunde
{
    class Program
    {
        struct Date
        {
            public int an, luna, zi, ore, minute, secunde;
            public Date(int _an, int _luna, int _zi, int _ore, int _minute, int _secunde )
            {
                this.an = _an;
                this.luna = _luna;
                this.zi = _zi;
                this.ore = _ore;
                this.minute = _minute;
                this.secunde = _secunde;
            }

            public Date(int _an,  int _luna, int _zi ) : this(_an,_luna,_zi,0,0,0)
            { }

            public override string ToString()
            {
                return this.zi + ". " + this.luna + " " + this.an;
            }
        }
        static void Main(string[] args)
        {
            Date inceput = new Date(2019, 1, 1,14,5,3);
            Date sfarsit = new Date(2019, 2, 1,15,50,10);

            int diferentaInZile = Diferenta(inceput, sfarsit);
            int diferentaInSecunde = ConvertesteInSecunde(diferentaInZile, "zile");

            //luam de la inceput
            diferentaInSecunde -= ConvertesteInSecunde(inceput.ore,"ore");
            diferentaInSecunde -= ConvertesteInSecunde(inceput.minute, "minute");
            diferentaInSecunde -= inceput.secunde;

            //adaugam la sfarsit
            diferentaInSecunde += ConvertesteInSecunde(sfarsit.ore, "ore");
            diferentaInSecunde += ConvertesteInSecunde(sfarsit.minute, "minute");
            diferentaInSecunde += sfarsit.secunde;

            Console.WriteLine(diferentaInSecunde);

            Console.ReadKey();
        }

        private static int ConvertesteInSecunde(int numar, string tip)
        {
            switch (tip)
            {
                case "zile":
                    return numar * 86400;
                case "ore":
                    return numar * 3600;
                case "minute":
                    return numar * 60;
                default:
                    return 0;
            }
        }

        private static int Diferenta(Date inceput, Date sfarsit)
        {
            int a = DiferentaDeAniInZile(inceput.an, sfarsit.an);
            int b = NumarDeZileDinAcelasAn(new Date(inceput.an, 1, 1), inceput);
            int c = NumarDeZileDinAcelasAn(new Date(sfarsit.an,1, 1 ), sfarsit);
            return a-b+c;
        }

        private static int DiferentaDeAniInZile(int inceput, int sfarsit)
        {
            int totalAni = sfarsit - inceput;
            int numarAniBisecti = 0;

            for (int i = inceput; i < sfarsit; i++)
                if (EAnBisect(i))
                    numarAniBisecti++;

            // fie a = numarul de ani bisecti si b = numarul de ani care nu sunt bisecti
            // din asta rezulta ca diferenta de ani in zile este a*364 + b*365
            // dar b se poate scrie ca numarul total de ani - numarul de ani bisecti
            // deci rezulta a*364 + (total-a)*365 = a*364 + total*365 - a*365, vom extrage a din ecuatie
            // ne va ramane a*(364 - 365) + total*365 <=> total*365 - a

            return totalAni * 365 - numarAniBisecti;

        }

        private static bool EAnBisect(int an)
        {
            return an % 4 == 0;
        }

        private static int NumarDeZileDinAcelasAn(Date inceput, Date sfarsit)
        {
            //daca este aceasi luna, atunci ne intereseaza doar diferenta dintre zile
            if (inceput.luna == sfarsit.luna)
                return sfarsit.zi - inceput.zi;

            int suma = 0;
            for (int i = inceput.luna; i < sfarsit.luna; i++)
                suma += NumarDeZileIntroLunaDupaAn(inceput.an,i); //inceput si sfarsit au acelas an, deci nu conteaza pe care-l pun

            //forul de mai sus ruleaza exclusiv pana la luna de sfarsit si ne mai raman cateva zile pe care nu le-am luat inca in calcul
            suma += sfarsit.zi;

            return suma;
        }

        private static int NumarDeZileIntroLunaDupaAn(int an, int luna)
        {
            int[] zileleLuni = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            luna--; //pentru a ca vectorul de mai sus incepe de la 0, iar noi avem prima luna (Ianuarie) fiind 1

            if (luna == 2) //daca cere luna Februarie
                if (EAnBisect(an)) // este an bisect
                    return zileleLuni[luna] + 1; // va fii 28+1
        
            return zileleLuni[luna]; 
        }
    }
}
