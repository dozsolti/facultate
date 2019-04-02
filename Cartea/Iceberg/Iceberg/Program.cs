using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iceberg
{
    class Program
    {
        static int[,] iceberg;
        static void Main(string[] args)
        {
            iceberg  = InitializeazaIcerbergul();
            Afiseaza();

            int nrPasi = 0;
            while (PotTopi())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pasul numarul: "+nrPasi);
                Topeste();
                Afiseaza();
                nrPasi++;
            }
            Console.ReadKey();
        }

        private static void Topeste()
        {
            int[,] _iceberg = new int[iceberg.GetLength(0), iceberg.GetLength(1)];
            for (int i = 0; i < iceberg.GetLength(0); i++)
                for (int j = 0; j < iceberg.GetLength(1); j++)
                    _iceberg[i, j] = iceberg[i,j];

            for (int i = 1; i < iceberg.GetLength(0) - 1; i++)
                for (int j = 1; j < iceberg.GetLength(1) - 1; j++)
                {
                    if (iceberg[i, j] == 1 && NumarVecini(i, j) > 1)
                        _iceberg[i, j] = 0;
                }

            for (int i = 0; i < iceberg.GetLength(0); i++)
                for (int j = 0; j < iceberg.GetLength(1); j++)
                    iceberg[i, j] = _iceberg[i, j];
        }

        private static int NumarVecini(int i,int j)
        {
            int nrVecini = 0;
            if (iceberg[i-1, j] == 0)
                nrVecini++;
            if (iceberg[i+1, j] == 0)
                nrVecini++;
            if (iceberg[i, j-1] == 0)
                nrVecini++;
            if (iceberg[i, j+1] == 0)
                nrVecini++;
            return nrVecini;
        }

        private static bool PotTopi()
        {
            for (int i = 0; i < iceberg.GetLength(0); i++)
                for (int j = 0; j < iceberg.GetLength(1); j++)
                    if (iceberg[i, j] == 1)
                        return true;
            return false;
        }

        private static void Afiseaza()
        {
            //Console.Clear();
            for (int i = 0; i < iceberg.GetLength(0); i++) {
                for (int j = 0; j < iceberg.GetLength(1); j++)
                {
                    if (iceberg[i, j] == 1)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("&");
                }
                Console.WriteLine();
            }
        }

        private static int[,] InitializeazaIcerbergul()
        {
            return new int[,]{
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,1,1,0,0,0},
                {0,0,1,1,1,1,1,1,0,0},
                {0,0,1,1,1,1,1,1,1,0},
                {0,1,1,1,1,1,1,1,1,0},
                {0,1,1,1,1,1,1,1,0,0},
                {0,0,1,1,1,1,1,1,0,0},
                {0,0,1,1,1,1,1,1,0,0},
                {0,0,1,1,1,1,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0}
            };
        }

        
    }
}
