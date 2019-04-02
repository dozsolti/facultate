using System;

namespace ApaDintrunVector
{
    class Program
    {
        static int[] vectorulCuApa;
        static int[,] matriceaCuApa;

        static void Main(string[] args)
        {
            vectorulCuApa = new int[] { 3, 1, 1, 2, 3, 1, 2, 5, 3, 2, 1, 1, 3, 2, 3, 1 };
            int max = vectorulCuApa[0];
            for (int i = 1; i < vectorulCuApa.Length; i++)
                if (max < vectorulCuApa[i])
                    max = vectorulCuApa[i];

            //transform vectorul de mai sus intr-o matrice
            matriceaCuApa = new int[max, vectorulCuApa.Length];
            for (int i = 0; i < matriceaCuApa.GetLength(0); i++)
                for (int j = 0; j < matriceaCuApa.GetLength(1); j++)
                    if (matriceaCuApa.GetLength(0) - i <= vectorulCuApa[j])
                        matriceaCuApa[i, j] = 1;
                    else
                        matriceaCuApa[i, j] = 0;

            Afisare();
            //ma duc din stanga si din dreapta spre directia opusa si pun cate un 2 daca acolo este pozitie libera
            for (int i = 0; i < matriceaCuApa.GetLength(0); i++)
            {
                int j = 0;
                while(matriceaCuApa[i,j]==0 && j< matriceaCuApa.GetLength(1))
                {
                    matriceaCuApa[i, j] = 2;
                    j++;
                }
                j = matriceaCuApa.GetLength(1) - 1;
                while (matriceaCuApa[i, j] == 0 && j>=0)
                {
                    matriceaCuApa[i, j] = 2;
                    j--;
                }
            }
            Console.WriteLine();
            Afisare();

            //dupa ce s-au pus toate 2urile tot ce a ramas cu 0 va insemna apa, acuma trebuie doar numarate
            int apaDinVector = 0;
            for (int i = 0; i < matriceaCuApa.GetLength(0); i++)
                for (int j = 0; j < matriceaCuApa.GetLength(1); j++)
                    if (matriceaCuApa[i, j] == 0)
                        apaDinVector++;
            Console.WriteLine("Vectorul poate retine {0} apa",apaDinVector);
            Console.ReadKey();
        }

        private static void Afisare()
        {
            for (int i = 0; i < matriceaCuApa.GetLength(0); i++) {
                for (int j = 0; j < matriceaCuApa.GetLength(1); j++)
                    if(matriceaCuApa[i,j]==1)
                        Console.Write("*");
                    else if(matriceaCuApa[i, j] == 2)
                        Console.Write("X");
                        else
                        Console.Write(" ");
                Console.WriteLine();
            }
        }
    }
}
