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
            m = new int[10, 10];
            k = 0;
            int n;
            a:
            SuffleLevel();
            UpdateScreen();
            while (!isLevelDone())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Pana acum ai facut {0} (de) pasii",k);
                Console.WriteLine("Te rog sa introduci o noua culoare:\n( 0 = Rosu, 1 = Albastru, 2 = Verde, 3 = Galben )");
                try
                {
                    n = int.Parse(Console.ReadKey().KeyChar.ToString()) % 4;
                    k++;
                }
                catch (FormatException err) {
                    return;
                }
                ChangeColor(n);
                UpdateScreen();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bravo ai castigat!!");
            Console.WriteLine("Vrei sa te joci din nou?");
            Console.ReadKey();
            goto a;
            
        }

        private static void ChangeColor(int n)
        {
            if (m[0, 0] == m[0, 1])
                ChangeColorOn(n, m[0, 0], 0, 1);
            if (m[0, 0] == m[1, 0])
                ChangeColorOn(n, m[0, 0], 1, 0);
            m[0, 0] = n;
        }

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

        private static void SuffleLevel()
        {
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    m[i, j] = rnd.Next(4);

        }

        private static void UpdateScreen()
        {
            //print level/m
            Console.Clear();
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.ForegroundColor = nToColor(m[i,j]);
                    Console.Write("██");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Consola are nevoie de date de tip ConsoleColor (si cu int) ca sa afiseze dupa culoare.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
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
