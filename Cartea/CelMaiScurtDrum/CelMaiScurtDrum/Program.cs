using System;
using System.Collections;

namespace CelMaiScurtDrum
{
    class Program
    {
        static Random rnd=new Random();
        static void Main(string[] args)
        {
            
            int[,] m = new int[10,10];
            for (int i = 0; i < m.GetLength(0); i++)
            {
                m[i, 0] = 1;
                m[i, m.GetLength(1)-1] = 1;
            }
            for (int j = 0; j < m.GetLength(1); j++)
            {
                m[0, j] = 1;
                m[m.GetLength(0) - 1,j] = 1;
            }
            for (int i = 1; i < m.GetLength(0)-1; i++)
            {
                for (int j = 1; j < m.GetLength(1)-1; j++)
                    if (rnd.Next(100) < 10)
                        m[i, j] = 1;
            }
            int startX = 1, startY = 0;
            m[startY,startX] = 2;

            int finalX = m.GetLength(1)-2, finalY= m.GetLength(0)-1;
            m[ finalY,finalX] = 0;
            Afiseaza(m);

            Queue lista = new Queue();
            lista.Enqueue(new int[] {  startY,startX });
            while (lista.Count != 0)
            {
                int[] element = (int[])lista.Dequeue();
                int elementValue = m[element[0], element[1]];

                //In jos
                if (element[0] + 1 < m.GetLength(0) && m[element[0] + 1, element[1]] == 0)
                {
                    lista.Enqueue(new int[] { element[0] + 1, element[1] });
                    m[element[0] + 1, element[1]] = elementValue + 1;
                }
                //In Sus
                if (element[0] - 1 >=0 && m[element[0] - 1, element[1]] == 0)
                {
                    lista.Enqueue(new int[] { element[0] - 1, element[1] });
                    m[element[0] - 1, element[1]] = elementValue + 1;
                }
                //La stanga
                if (element[1] - 1 >= 0 && m[element[0] , element[1]- 1] == 0)
                {
                    lista.Enqueue(new int[] { element[0] , element[1]- 1 });
                    m[element[0], element[1]- 1] = elementValue + 1;
                }
                //La Dreapta
                if (element[1] + 1 < m.GetLength(1) && m[element[0], element[1] + 1] == 0)
                {
                    lista.Enqueue(new int[] { element[0], element[1] + 1 });
                    m[element[0], element[1] + 1] = elementValue + 1;
                }
            }
            Console.WriteLine();
            Afiseaza(m);
            //Dupa alg se pot deduce urm info din m:
            //Daca pe positia de finala este 0 nu exista drum
            Console.ReadKey();
        }

        private static void Afiseaza(int[,] m)
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                    if (m[i, j] == 1)
                        Console.Write("██ ");
                    else
                        Console.Write(m[i,j].ToString("00 "));
                Console.WriteLine();
            }
        }
    }
}
