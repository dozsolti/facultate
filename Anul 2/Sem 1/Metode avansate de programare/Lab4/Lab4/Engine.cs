using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public static class Engine
    {
        public static int n, m;
        public static int[,] matrix;
        public static Random r = new Random();
        public static Panel display;

        public static void Init(Panel p) {
            display = p;
            n = 16;
            m = 14;
            matrix = new int[n, m];
            int k = 0, count = 0;
            for(int i=0;i<n;i++)
                for(int j=0;j<m;j++)
                {
                    matrix[i, j] = k;
                    count++;
                    if(count==4)
                    {
                        k++;
                        count = 0;
                    }
                }
            Shuffle();

        }
        public static void Shuffle()
        {
            for(int i=0;i<n;i++)
                for (int j = 0; j < m; j++)
                {
                    int l = r.Next(n);
                    int c = r.Next(m);
                    int aux = matrix[i, j];
                    matrix[i, j] = matrix[l, c];
                    matrix[l, c] = aux;
                }
        }
    }
}
