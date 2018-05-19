using System;

namespace ConsoleApplication54
{
    class Program
    {
        static int[][] spectacole = new int[][] {
            new int[]{18,22 },
            new int[]{10,20 },
            new int[]{20,23 }
        };
        static void Main(string[] args)
        {
            sorteazaSpectacolele();
            Console.WriteLine(spectacole[0][0]+"-"+spectacole[0][1]);
            int selectedIndex = 0;
            for(int i = 1; i < spectacole.GetLength(0); i++)
            {
                if (spectacole[i][0]>=spectacole[selectedIndex][ 1]) {
                    selectedIndex = i;
                    Console.WriteLine(spectacole[i][ 0] + "-" + spectacole[i][ 1]);
                }
            }
            Console.ReadKey();
        }
        static void sorteazaSpectacolele()
        {
            for (int j = 0; j < spectacole.GetLength(0) - 1; j++)
            {
                int mini = j;
                for (int i = j + 1; i < spectacole.GetLength(0); i++)
                    if (spectacole[i][1] < spectacole[mini][1])
                        mini = i;

                if (mini != j)
                {
                    int[] temp = spectacole[j];
                    spectacole[j] = spectacole[mini];
                    spectacole[mini] = temp;
                }
            }
        }
    }
}
