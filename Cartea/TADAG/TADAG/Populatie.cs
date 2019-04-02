using System;

namespace TADAG
{
    public class Populatie
    {
        public static int numarGeneratie;
        public static int numarGene = 5;

        public int numarTotalCromozomi;
        public int numarCromozomiParinti;

        public Cromozom[] cromozomi;
        public Cromozom[] parinti;

        public Populatie(int numarDeCromozomi, int numarDeCromozomiParinti)
        {
            numarTotalCromozomi = numarDeCromozomi;
            numarCromozomiParinti = numarDeCromozomiParinti;

            cromozomi = new Cromozom[numarTotalCromozomi];
            parinti = new Cromozom[numarCromozomiParinti];

            for (int i = 0; i < numarTotalCromozomi; i++)
                cromozomi[i] = new Cromozom();
            numarGeneratie = 1;
        }
        public void SeteazaParintii()
        {
            Ordonare();
            for (int i = 0; i < numarCromozomiParinti; i++)
                parinti[i] = cromozomi[i];
        }
        public void Ordonare()
        {
            for (int i = 0; i < numarTotalCromozomi - 1; i++)
                for (int j = i + 1; j < numarTotalCromozomi; j++)
                    if (cromozomi[i].Adecvare() < cromozomi[j].Adecvare())
                    {
                        Cromozom c = cromozomi[i];
                        cromozomi[i] = cromozomi[j];
                        cromozomi[j] = c;
                    }
        }

        public void Actualizare()
        {
            SeteazaParintii();
            for (int i = 0; i < numarTotalCromozomi; i++)
            {
                Cromozom[] parintiTemp = ExtrageDoiParinti();
                Cromozom temp = new Cromozom(parintiTemp[0], parintiTemp[1]);
                temp.Mutatie();
                cromozomi[i] = temp;
            }
            numarGeneratie++;

        }

        private Cromozom[] ExtrageDoiParinti()
        {
            int i, j;
            do
            {
                i = Program.rnd.Next(numarCromozomiParinti);
                j = Program.rnd.Next(numarCromozomiParinti);
            } while (i == j);

            return new Cromozom[]{ parinti[i], parinti[j]};
        }

        public void Afisare()
        {
            Console.WriteLine("Generatia #{0}",numarGeneratie );
            foreach (Cromozom cromozom in cromozomi)
            {
                Console.WriteLine(cromozom.ToString());
            }
            Console.WriteLine();
        }
    }
}