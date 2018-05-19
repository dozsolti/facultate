using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication53
{
    class Program
    {
        static int[,] monede = new int[,] {
            {25,0 },
            {10,0 },
            {5,0 },
            {1,0 }
        };
        static void Main(string[] args)
        {
            int sum = 18956;
            int i = 0;
            while (sum > 0)
            {
                if (sum - monede[i, 0] >= 0)
                {
                    sum -= monede[i, 0];
                    monede[i, 1]++;
                    i = 0;
                }
                else
                    i++;
            }
            Console.WriteLine("trebuie sa platesti: ");
            for (i = 0; i < monede.GetLength(0); i++)
            {
                if(monede[i,1]>0)
                    Console.WriteLine("{0}x {1}",monede[i,0], monede[i, 1]);
            }
            Console.ReadKey();
        }
    }
}
