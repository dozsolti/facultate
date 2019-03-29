using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcuatieGenetica
{
    class Program
    {
        public static Random rnd;
        public static int n;

        public static float[,] Ecuatie;
        public static float[] TermeniLiberi;

        static void Main(string[] args)
        {
            rnd = new Random();
            Citit();
            //Afisare();

            AlgGenetic.InitPop(200, 80);
            while(true)
            {
                Console.Clear();
                AlgGenetic.NextGeneration();
                AlgGenetic.View();
                Console.ReadKey();

            }

            Console.ReadKey();
        }
        static void Citit()
        {
            TextReader dataLoader = new StreamReader("../../Ecuatie.txt");
            string buffer;
            string[] x;
            n = int.Parse(dataLoader.ReadLine());
            Ecuatie = new float[n, n];
            TermeniLiberi = new float[n];
            for(int i=0; i < n; i++)
            {
                buffer = dataLoader.ReadLine();
                x = buffer.Split(' ');
                for (int j = 0; j < n; j++)
                    Ecuatie[i, j] = float.Parse(x[j]);
            }
            buffer = dataLoader.ReadLine();
            x = buffer.Split(' ');
            for (int i = 0; i < n; i++)
                TermeniLiberi[i] = float.Parse(x[i]);
        }
        static void Afisare()
        {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++)
                    Console.Write(Ecuatie[i,j]+" *x"+j+"\t");
                Console.Write("="+TermeniLiberi[i]);
                Console.WriteLine();
            }

        }
    }
}
