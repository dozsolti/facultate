using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    public static class Engine
    {
        public static Random r = new Random();
        public static List<Solution> sol = new List<Solution>();
        public static int K = 6,N = 200*2;
        public static List<Solution> par = new List<Solution>();
        public static Solution best;
        public static void Do()
        {
            par.Clear();
            SortSol();
            for (int i = 0; i < K; i++)
                par.Add(sol[i]);

            if (sol[0].steps > best.steps)
            {
                best = sol[0];
                Console.WriteLine("The best : " + best.View());
            }

            sol.Clear();
            sol.Add(par[0]);
            for (int i = 1; i < N; i++)
                    sol.Add(Mutate(Cross(par[r.Next(K)], par[r.Next(K)])));
        }

        public static Solution Cross(Solution a, Solution b)
        {
            Solution mix = new Solution();
            int mijloc = r.Next(7, 9);
            mix.values = long.Parse(a.values.ToString().Substring(0, mijloc) + b.values.ToString().Substring(mijloc));
            if (a.values.ToString().Length != 15|| b.values.ToString().Length != 15 || mix.values.ToString().Length != 15)
                throw new Exception("oh oh");
            mix.CalcSteps();
            return mix;
        }
        public static void SortSol()
        {
            for (int i = 0; i < K - 1; i++)
            {
                // Find the minimum element in unsorted array
                int mini = i;
                for (int j = i + 1; j < sol.Count; j++)
                    if (sol[j].steps > sol[mini].steps)
                        mini = j;

                // Swap the found minimum element with the first element
                Solution temp = sol[mini];
                sol[mini] = sol[i];
                sol[i] = temp;
            }
        }
        public static Solution Mutate(Solution T)
        {
            Solution mix = new Solution();
            string x = T.values.ToString();
            if (x.Length != 15)
                throw new Exception("oh oh");
            string y = "";
            for (int i = 0; i < 3; i++)
            {
                int pos = r.Next(x.Length);
                if (pos == 0)
                    y = Engine.r.Next(1, 10) + x.Substring(1);
                else
                    y = x.Substring(0, pos) + Engine.r.Next(10) + x.Substring(pos + 1);
            }
            mix.values = long.Parse(y);
                if (mix.values.ToString().Length != 15)
                    throw new Exception("oh oh");
            
            mix.CalcSteps();
            return mix;
        }

        public static void Init()
        {
            for (int i = 0; i < N; i++)
                sol.Add(new Solution());
            best = sol[0];
            //Do();
        }
    }
}
