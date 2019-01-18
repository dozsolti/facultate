using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridByOpinion
{
    public static class GridManager
    {
        public static int[,] GetRandomGrid()
        {
            int[,] m = new int[23, 9];
            for (int i = 0; i < 23; i++)
                for (int j = 0; j < 9; j++)
                    m[i, j] = Engine.rnd.Next(2);
            return m;
        }

        internal static int[,] Mutate(int[,] m)
        {
            for (int i = 0; i < 23; i++)
                for (int j = 0; j < 9; j++)
                {
                    int nr = Engine.rnd.Next(100);
                    if (nr < 30)
                        m[i, j] = Engine.rnd.Next(2);
                    if (nr>=30 && nr < 60)
                        m[i, j] = 1-m[i, j];
                }
            return m;
        }
    }
}
