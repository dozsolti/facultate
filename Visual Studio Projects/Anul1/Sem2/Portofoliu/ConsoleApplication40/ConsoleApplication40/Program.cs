using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication40
{
    class Program
    {
        static Random rnd;
        static void Main(string[] args)
        {
            rnd = new Random();
            int[,] input = { { 1, 5 }, {2,5 }, { 3,5} };
            int[] aparitii = new int[input.GetLength(0)];
            for(int i = 0; i < 100; i++)
            {
                int n = getRandomNr(input);
                aparitii[n - 1]++;
            }
            for (int i = 0; i < aparitii.Length; i++)
                Console.WriteLine((i+1)+" a aparut de "+ aparitii[i]+" ori");
            Console.ReadKey();
        }

        private static int getRandomNr(int[,] input)
        {
            int maxLen = 0;
            for(int i = 0; i < input.GetLength(0); i++)
                maxLen += input[i, 1];

            int rndN = rnd.Next(maxLen);
            int j = 0;
            while (input[j, 1] < rndN && j < input.GetLength(0) - 1)
            {
                rndN -= input[j, 1];
                j++;
            }
            return input[j, 0];
        }
    }
}
