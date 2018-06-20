using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication71
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            List<int> A = new List<int>{ -6,1,-3,4,5,-1,3,-8, -9, 1 };
            List<int> temp = new List<int>();
            int sumMax = int.MinValue;

            for (int i = 0; i < A.Count; i++)
            {
                for (int j = 0; j < A.Count-i; j++)
                {
                    int sum = GetListSum(A.GetRange(i, A.Count - i - j));
                    
                    if (sumMax < sum)
                        sumMax = sum;
                }
            }
            Console.WriteLine(sumMax);
            Console.ReadKey();
        }

        private static int GetListSum(List<int> list)
        {
            int sum = 0;
            foreach (int i in list)
                sum += i;
            return sum;
        }

        static void printList(List<int> a)
        {
            foreach (int item in a)
                Console.Write(item + " ");
            Console.WriteLine();
            
        }
    }
}
