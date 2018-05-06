using System;
using System.Collections.Generic;

namespace GeneticAlg1820
{
    internal class Population
    {
        private float mutationRate;
        DNA[] population;             // Array to hold the current population
        List<DNA> matingPool;    // ArrayList which we will use for our "mating pool"
        public int generations=0;              // Number of generations
        bool finished;             // Are we finished evolving?
        int perfectScore;
        Random rnd;
        public Population(float mutationRate, int popmax)
        {
            this.mutationRate = mutationRate;
            population = new DNA[popmax];
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new DNA(15);
            }
            calcFitness();
            matingPool = new List<DNA>();
            finished = false;

            rnd = new Random();
            perfectScore = 1820;
        }

        internal void naturalSelection()
        {
            // Clear the ArrayList
            matingPool.Clear();

            float maxFitness = 0;
            int ind = 0;
            for (int i = 0; i < population.Length; i++)
            {
                if (population[i].fitness > maxFitness)
                {
                    ind = i;
                    maxFitness = population[i].fitness;
                }
            }
            if (maxFitness > 1000)
                Console.WriteLine(population[ind].getPhrase() +" "+ maxFitness);
            // Based on fitness, each member will get added to the mating pool a certain number of times
            // a higher fitness = more entries to mating pool = more likely to be picked as a parent
            // a lower fitness = fewer entries to mating pool = less likely to be picked as a parent
            for (int i = 0; i < population.Length; i++)
            {

                float fitness = map(population[i].fitness, 0, maxFitness, 0, 1);
                int n = (int)(fitness * 10);  // Arbitrary multiplier, we can also use monte carlo method
                for (int j = 0; j < n; j++)
                {              // and pick two random numbers
                    matingPool.Add(population[i]);
                }
            }
        }

        private float map(float value,float from, float to, float from2, float to2)
        {
            if (value <= from2)
            {
                return from;
            }
            else if (value >= to2)
            {
                return to;
            }
            else
            {
                return (to - from) * ((value - from2) / (to2 - from2)) + from;
            }
        }

        internal void generate()
        {
            generations++;
            // Refill the population with children from the mating pool
            for (int i = 0; i < population.Length; i++)
            {
                
                int a = rnd.Next(matingPool.Count);
                int b = rnd.Next(matingPool.Count);
                DNA partnerA = matingPool[a];
                DNA partnerB = matingPool[b];
                DNA child = partnerA.crossover(partnerB);
                child.mutate(mutationRate);
                population[i] = child;
            }
        }

        internal void calcFitness()
        {
            for (int i = 0; i < population.Length; i++)
            {
                population[i].updateFitness();
            }
        }

        internal bool isFinished()
        {
            return finished;
        }

        internal object getAverageFitness()
        {
            float total = 0;
            for (int i = 0; i < population.Length; i++)
            {
                total += population[i].fitness;
            }
            return total / (population.Length);
        }

        

        internal string getBest()
        {
            float worldrecord = 0;
            int index = 0;
            for (int i = 0; i < population.Length; i++)
            {
                if (population[i].fitness > worldrecord)
                {
                    index = i;
                    worldrecord = population[i].fitness;
                }
            }


            if (worldrecord >= perfectScore - 5)
            {
                finished = true;
                Console.WriteLine("Am gaasit: " + population[index].getPhrase());
            }
            return population[index].getPhrase();
        }
        
    }
}