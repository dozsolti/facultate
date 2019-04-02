using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    class Program
    {
        //Enunt: Intr-un sac sunt puse niste obiecte de diferite dimensiuni. Astfel cand la o extragere sunt sanse mai mari sa apuci un obiect mai mare decat unul mic.
        // Folosind algoritmul Monte Carlo sa se construiasca un algoritm care sa simuleze extragerea.
        struct Obiect
        {
            public string nume;
            public int dimensiune;
            public Obiect(string _nume, int _dimensiune)
            {
                this.nume = _nume;
                this.dimensiune = _dimensiune;
            }
        }
        static void Main(string[] args)
        {
            Obiect[] sac =
                {
                    new Obiect("caciula verde",2),
                    new Obiect("caciula rosie",2),
                    new Obiect("stilou", 1),
                    new Obiect("scaun", 5),
                    new Obiect("mar", 3)
                };

            Random rnd = new Random();

            int dimensiuneaSacului = 0;
            foreach (Obiect obiect in sac)
                dimensiuneaSacului += obiect.dimensiune;

            //luam un numar aleator din sac
            int numarAleator = rnd.Next(dimensiuneaSacului);

            //e ca si cum ar fii 2 caciuli verzi, 2 caciuli rosii, 1 stilou, 5 scaune, 3 mere

            // transformam numar intr-un obiect
            int i = 0;
            while (numarAleator - sac[i].dimensiune > 0) {
                numarAleator -= sac[i].dimensiune;
                i++;
            }

            Console.WriteLine(sac[i].nume);

            Console.ReadKey();
        }
    }
}
