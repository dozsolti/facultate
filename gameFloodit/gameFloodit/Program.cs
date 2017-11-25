using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameFloodit
{
    class Program
    {
        static Random rnd;
        static int[,] m;
        static int k;
        static void Main(string[] args)
        {
            rnd = new Random();

            m = new int[10, 10]; // Nivelul
            int n;// Noua culoare

            a:
            //Se reseteaza numarul de pasii
            k = 0;
            //Crearea unui nivel nou
            SuffleLevel();
            //Afisare
            UpdateScreen();

            //Cat timp nu e jocul terminat
            while (!isLevelDone())
            {
                //Start: Afisarea informatiilor secundare
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Pana acum ai facut {0} (de) pasii",k);
                Console.WriteLine("Te rog sa introduci o noua culoare:\n( 0 = Rosu, 1 = Albastru, 2 = Verde, 3 = Galben )");
                //End: Afisarea informatiilor secundare
                
                //Start: Se citeste o culoare noua
                try
                {
                    n = int.Parse(Console.ReadKey().KeyChar.ToString()) % 4;
                    k++;
                }
                catch (FormatException err) {
                    //Daca nu este un numar jocu se va opri
                    return;
                }
                //Schimba culoriile
                ChangeColors(n);
                //Afiseaza nivelul din nou, dupa schimbari
                UpdateScreen();
            }

            //Ai iesit din while/ ai terminat jocul
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ai castigat!! In doar {0} (de) pasi",k);
            Console.WriteLine("Apasa orice pentru a juca din nou.");
            Console.ReadKey();
            //Inapoi la inceput
            goto a;
            
        }
        /// <summary>
        /// Incepe procesul de schimbarea culoriilor
        /// </summary>
        /// <param name="n">Culoarea noua</param>
        private static void ChangeColors(int n)
        {

            if (m[0, 0] == m[0, 1])
                ChangeColorOn(n, m[0, 0], 0, 1);

            if (m[0, 0] == m[1, 0])
                ChangeColorOn(n, m[0, 0], 1, 0);

            m[0, 0] = n;
        }
        /// <summary>
        /// Aceasta functie va schimba culoriile pe poziitile i,j.
        /// De notat ca este important din ce culoare schimbi!
        /// </summary>
        /// <param name="colorTo">Culoarea in care trebuie schimbat</param>
        /// <param name="colorFrom">Culoarea din care trebuie schimbat</param>
        /// <param name="i">Rand din m</param>
        /// <param name="j">Coloana din m</param>
        private static void ChangeColorOn(int colorTo,int colorFrom,int i,int j)
        {
            if (colorFrom == m[i, j])
            {
                if (j + 1 < m.GetLength(1)) {
                    if (colorFrom == m[i, j + 1])
                        ChangeColorOn(colorTo, m[i, j], i, j + 1);
                }
                if (i + 1 < m.GetLength(0))
                {
                    if (colorFrom == m[i+1, j])
                        ChangeColorOn(colorTo, m[i, j], i+1, j);
                }
                m[i, j] = colorTo;
            }
        }

        /// <summary>
        /// Ne va spune daca nivelul este complet.
        /// </summary>
        /// <returns>Toate elementele sunt asemanatoare?</returns>
        private static bool isLevelDone()
        {
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    for (int i2 = 0; i2 < m.GetLength(0); i2++)
                        for (int j2 = 0; j2 < m.GetLength(1); j2++)
                            if (m[i, j] != m[i2, j2])
                                return false;
                }
            return true;
        }

        /// <summary>
        /// Ne genereaza un nivel nou
        /// </summary>
        private static void SuffleLevel()
        {
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    m[i, j] = rnd.Next(4);

        }

        /// <summary>
        /// Acesta functie va afisa jocul
        /// </summary>
        private static void UpdateScreen()
        {
            //Sterge jocul anterior
            Console.Clear();

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    //Se seteaza culoare pe baza de numar
                    Console.ForegroundColor = nToColor(m[i,j]);
                    //Se afiseaza un element
                    Console.Write("██");
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Consola are nevoie de date de tip ConsoleColor (si cu int) ca sa afiseze dupa culoare.
        /// </summary>
        /// <param name="n">Numarul culorii</param>
        /// <returns>Returneaza culoare pe baza de numar</returns>
        private static ConsoleColor nToColor(int n)
        {
            if (n == 0)
                return ConsoleColor.Red;
            else if (n == 1)
                return ConsoleColor.Blue;
            else if (n == 2)
                return ConsoleColor.Green;
            else
                return ConsoleColor.Yellow;
        }
    }
}
