using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication39
{
    class Program
    {
        static int n;
        static int[,] m;
        static Random rnd;
        static void Main(string[] args)
        {
            rnd = new Random();
            n = 4;
            m = new int[n, n];
            Amesteca();
            while (!eBun())
                Amesteca();
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0;j  < n; j++)
                    Console.Write(m[i,j]+" ");
            }
            Console.ReadKey();
        }

        private static bool eBun()
        {
            int sum0 = 0;
            int sum = 0;
            //prima coloana
            for (int i = 0; i < n; i++)
                sum0 += m[i, 0];

            //diag principala
            sum = 0;
            for (int i = 0; i < n; i++)
                sum += m[i, i];
            if (sum0 != sum)
                return false;

            //diag secundara
            sum = 0;
            for (int i = 0; i < n; i++)
                sum += m[n-i-1, i];
            if (sum0 != sum)
                return false;

            //coloane
            for (int i = 1; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                    sum += m[i, j];
                if (sum0 != sum)
                    return false;
            }
            //randuri
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                    sum += m[j, i];
                if (sum0 != sum)
                    return false;
            }

            return true;
        }

        private static void Amesteca()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    m[i, j] = -1;
            int nr = rnd.Next(1,n*n+1);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    while (Contine(nr))
                        nr = rnd.Next(1, n * n + 1);
                    m[i, j] = nr;
                }

        }

        private static bool Contine(int nr)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (m[i, j] == nr)
                        return true;
            return false;
        }
    }
}
