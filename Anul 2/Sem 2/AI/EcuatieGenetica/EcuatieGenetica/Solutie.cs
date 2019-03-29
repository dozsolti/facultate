using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcuatieGenetica
{
    public class Cromozon
    {
        public float[] gene;

        public Cromozon()
        {
            gene = new float[Program.n];
            for (int i = 0; i < gene.Length; i++)
                gene[i] = (float)Program.rnd.NextDouble()* 2000 - 1000;
        }
        public float GetFitness()
        {
            float r = 0;
            for(int j=0;j<Program.n;j++)
            {
                float aux = 0;
                for(int i = 0; i < Program.n; i++)
                    aux += Program.Ecuatie[i, j] * gene[i] - Program.TermeniLiberi[j];
                r += Math.Abs(aux);
            }
            return r;
        }
        public void Mutate()
        {
            int i = Program.rnd.Next(Program.n);
            gene[i] = (float)Program.rnd.NextDouble() * 2000 - 1000;
        }
        public void View()
        {
            Console.Write("(");
            for(int i=0;i<Program.n;i++)
                Console.Write(gene[i].ToString("0.000") + " ");
            Console.WriteLine(") "+GetFitness().ToString("0.000"));

        }
    }
}
