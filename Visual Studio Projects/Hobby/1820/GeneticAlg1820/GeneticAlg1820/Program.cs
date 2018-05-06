using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg1820
{
    class Program
    {
        static int popmax;
        static float mutationRate;
        static Population population;
        static void Main(string[] args)
        {
            popmax = 200;
            mutationRate = 0.1f;
            // Create a populationation with a target phrase, mutation rate, and populationation max
            population = new Population(mutationRate, popmax);
            while (true)
            {

                population.naturalSelection();
                //Create next generation
                population.generate();
                // Calculate fitness
                population.calcFitness();
                if(population.generations%100==0)
                    displayInfo();

                // If we found the target phrase, stop
                if (population.isFinished())
                {
                    Console.WriteLine("Am gatat");
                    break;
                }
            }
            Console.ReadKey();
            Console.ReadKey();
        }

        private static void displayInfo()
        {
            Console.Clear();
            Console.WriteLine(population.getBest());
            Console.WriteLine("total generations:     " + population.generations);
            Console.WriteLine("average fitness:       " + population.getAverageFitness());
        }
    }
}
