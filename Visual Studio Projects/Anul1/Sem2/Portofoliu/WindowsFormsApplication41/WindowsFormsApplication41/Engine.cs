using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication41
{
    public static class Engine
    {
        public static int n;
        public static float k = 2;
        public static Random r = new Random();
        public static int N = 20;
        public static int K = 10;
        public static List<Solution> sol = new List<Solution>();
        public static int[] v = { 2,3,5,0 };
        public static List<Solution> par = new List<Solution>();

        public static void Do()
        {
            par.Clear();
            sol.Sort(delegate (Solution a, Solution b) { return b.FAdec().CompareTo(a.FAdec()); });
            for (int i = 0; i < Math.Min(sol.Count,K); i++)
                par.Add(sol[i]);
            sol.Clear();

            sol.AddRange(par);
            for (int i = K; i < N; i++)
                sol.Add(Mutate(Cross(par[r.Next(K)], par[r.Next(K)])));
        }

        public static Solution Cross(Solution a, Solution b)
        {
            Solution mix = new Solution();
            for (int i = 0; i < n / 2; i++)
                mix.values[i] = a.values[i];

            for (int i = n / 2; i < n; i++)
                mix.values[i] = b.values[i];
            return mix;
        }

        public static Solution Mutate(Solution T)
        {
            Solution mix = new Solution();
            for (int i = 0; i < n; i++)
                mix.values[i] = T.values[i];

            int m = r.Next(10);
            while(mix.isInValues(m))
                m = r.Next(10);

            mix.values[r.Next(n)] = m;

            return mix;
        }

        public static void Init()
        {
            r = new Random();
            n = v.Length;
            for (int i = 0; i < N; i++)
                sol.Add(new Solution());
            Do();
        }

    }
}
