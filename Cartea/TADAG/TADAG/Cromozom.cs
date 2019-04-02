using System;
using System.Text;

namespace TADAG
{
    public class Cromozom
    {
        public int[] gene;
        public Cromozom()
        {
            gene = new int[Populatie.numarGene];
            for (int i = 0; i < gene.Length; i++)
                gene[i] = Program.rnd.Next(-10,10);
        }

        public Cromozom(Cromozom parinteA, Cromozom parinteB)
        {
            gene = new int[Populatie.numarGene];
            int punctTaietura = Program.rnd.Next(gene.Length);
            for (int i = 0; i < gene.Length; i++)
            {
                if (i < punctTaietura)
                    gene[i] = parinteA.gene[i];
                else
                    gene[i] = parinteB.gene[i];
            }
        }
        public void Mutatie()
        {
            int i = Program.rnd.Next(gene.Length);
            gene[i] = Program.rnd.Next(-10, 10);

        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (int gena in gene)
                stringBuilder.AppendFormat(gena + "\t");

            stringBuilder.AppendFormat(" = "+Adecvare() + "\t");

            return stringBuilder.ToString();
        }

        public int Adecvare()
        {
            int sum = 0;
            foreach (int gena in gene)
                sum += gena;

            return sum;
        }
    }
}