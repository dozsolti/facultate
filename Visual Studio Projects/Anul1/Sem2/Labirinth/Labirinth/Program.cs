using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinth
{
    class Program
    {
        static Random rnd;
        static int n = 8, c1, l1, c2, l2;
        static int[,] m;
        static Queue<Trivalue> nume = new Queue<Trivalue>();

        static void Main(string[] args)
        {
            rnd = new Random();
            m = new int[n, n];

            Generare();
            Afisare();
            //do{
            Console.Write("l1:");
            l1 = int.Parse(Console.ReadLine());
            Console.Write("c1:");
            c1 = int.Parse(Console.ReadLine());

            Console.Write("l2:");
            l2 = int.Parse(Console.ReadLine());
            Console.Write("c2:");
            c2 = int.Parse(Console.ReadLine());
            //} while (m[l1, c1] != 0 && m[l2, c2] != 0);

            nume.Enqueue(new Trivalue(l1, c1, 2));
            m[l1, c1] = 2;
            bool ok;
            do
            {
                ok = true;
                Trivalue t = nume.Dequeue();
                if (t.c - 1 >= 0)
                {
                    if (m[t.l, t.c - 1] == 0)
                    {
                        m[t.l, t.c - 1] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l, t.c - 1, t.v + 1));
                    }
                }
                if (t.c + 1 < n)
                {
                    if (m[t.l , t.c + 1] == 0)
                    {
                        m[t.l, t.c + 1] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l , t.c + 1, t.v + 1));
                    }
                }

                if (t.l - 1 >= 0)
                {
                    if (m[t.l - 1, t.c] == 0)
                    {
                        m[t.l-1, t.c] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l-1, t.c, t.v + 1));
                    }
                }
                if (t.l + 1 <n)
                {
                    if (m[t.l + 1, t.c] == 0)
                    {
                        m[t.l + 1, t.c] = t.v + 1;
                        nume.Enqueue(new Trivalue(t.l + 1, t.c, t.v + 1));
                    }
                }

                if (nume.Count == 0 || (t.l == l2 && t.c == c2))
                    ok = false;
            } while (ok);
            Afisare();
            Console.ReadKey();
        }
        static void Afisare()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }
        }
        static void Generare()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    m[i, j] = rnd.Next(4);
                    if (m[i, j] >= 2)
                        m[i, j] = 0;
                }
        }
    }
}
