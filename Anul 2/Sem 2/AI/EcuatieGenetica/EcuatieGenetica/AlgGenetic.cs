using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcuatieGenetica
{
    public static class AlgGenetic
    {
        static Cromozon[] cromozoni;
        static int N, K;

        public static void InitPop(int n,int k)
        {
            N = n;
            K = k;

            cromozoni = new Cromozon[N];

            for (int i = 0; i < N; i++)
                cromozoni[i] = new Cromozon();

            
        }
        public static void Ord()
        {
            List<Cromozon> temp = cromozoni.ToList();
            temp.Sort(delegate (Cromozon a, Cromozon b)
                {
                    return (int) (a.GetFitness() - b.GetFitness());
                });
            cromozoni = temp.ToArray();
        }

        internal static void NextGeneration()
        {
            Ord();
            
            for (int i = K; i < N; i++)
            {
                Cromozon temp = Incrucisare();
                temp.Mutate();
                cromozoni[i] = temp;
            }
            /*Cromozon[] nextGenes = new Cromozon[N];
            for (int i = 0; i < N/4; i++)
                nextGenes[i] = cromozoni[i];

            for (int i = N / 4; i < N*2 / 4; i++)
            {
                int j = Program.rnd.Next(K);
                cromozoni[j].Mutate();
                nextGenes[i] = cromozoni[j];
            }

            for (int i = N * 2 / 4; i < N*3 / 4; i++)
                nextGenes[i] = Incrucisare();

            for (int i = N * 3 / 4; i < N; i++)
                nextGenes[i] = new Cromozon();
            for(int i=0;i<N;i++)
                cromozoni[i] = nextGenes[i];*/
        }
        public static Cromozon Incrucisare()
        {
            int i, j;
            do
            {
                i = Program.rnd.Next(K);
                j = Program.rnd.Next(K);
            } while (i == j);

            Cromozon newCromozon = new Cromozon();
            newCromozon.gene[0] = cromozoni[i].gene[0];
            newCromozon.gene[1] = cromozoni[i].gene[1];
            newCromozon.gene[2] = cromozoni[j].gene[2];
            newCromozon.gene[3] = cromozoni[j].gene[3];
            newCromozon.gene[4] = cromozoni[j].gene[4];
            return newCromozon;
        }
        public static void View()
        {
            for (int i = 0; i < 10; i++)
                cromozoni[i].View();
        }
    }
}
