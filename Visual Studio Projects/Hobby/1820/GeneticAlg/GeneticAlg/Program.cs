using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine.Init();
            /*while (true)
            {
                displayInfo();
                Console.ReadKey();
            }*/
            while (Engine.best.steps < 1815)
                for (int i = 0; i < 2; i++)
                    Engine.Do();
            Console.ReadKey();
        }

        private static void displayInfo()
        {
            Console.Clear();
            Engine.Do();
            Engine.SortSol();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Engine.sol[i].View());
            }
            Console.WriteLine("The best : " + Engine.best.View());
        }
    }
}
