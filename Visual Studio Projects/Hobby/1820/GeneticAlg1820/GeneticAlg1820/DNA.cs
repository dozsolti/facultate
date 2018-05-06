using System;

namespace GeneticAlg1820
{
    internal class DNA
    {
        internal int[] genes;

        internal float fitness;
        Random rnd;

        public DNA(int num)
        {
            rnd = new Random();
            genes = new int[num];
            genes[0] = rnd.Next(5,10);
            for (int i =1; i < genes.Length; i++)
            {
                genes[i] = rnd.Next(10);  // Pick from range of chars
            }
        }

        internal void updateFitness()
        {
            int score = 0;
            long n = 0;
            for (int i = 0; i < genes.Length; i++)
                n = n * 10 + genes[i];

            do
            {
                score++;
                {
                    if (n % 2 == 0) n = n / 2;
                    else n = n * 3 + 1;
                }
            } while (n != 1);

            fitness = (int)score;
        }

        internal string getPhrase()
        {
            String res = "";
            for (int i = 0; i < genes.Length; i++)
                res += genes[i];
            return res;
        }

        internal void mutate(float mutationRate)
        {
            //genes[0] = (int)rnd.Next(5, 10);
            for (int i = 0; i < genes.Length; i++)
            {
                if (rnd.NextDouble() < mutationRate)
                {
                    genes[i] = (int)rnd.Next(0, 10);
                    if(i==0 && genes[i] == 0)
                    {
                        genes[i] = 5;
                    }
                }
            }
        }

        internal DNA crossover(DNA partner)
        {
            DNA child = new DNA(genes.Length);

            int midpoint = rnd.Next(genes.Length); // Pick a midpoint

            // Half from one, half from the other
            for (int i = 0; i < genes.Length; i++)
            {
                if (i > midpoint) child.genes[i] = genes[i];
                else child.genes[i] = partner.genes[i];
            }
            return child;
        }
    }
}