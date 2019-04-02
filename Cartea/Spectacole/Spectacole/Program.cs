using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectacole
{
    class Program
    {
        //Se organizeaza mai multe spectacole in aceasi zi. Fiecare spectacol avand o ora de inceput si unul de sfarsit.
        //Sa se scrie un program care, prin metoda Greedy, sa ordoneze spectacolele astfel inca sa se poata organiza un numarul maxim de spectacole fara suprapuneri

        struct Spectacol
        {
            public string nume;
            public int inceput;
            public int sfarsit;
            public Spectacol(string _nume, int _inceput, int _sfarsit)
            {
                this.nume = _nume;
                this.inceput = _inceput;
                this.sfarsit = _sfarsit;
            }
        }
        static void Main(string[] args)
        {

            Spectacol[] spectacole = {
                new Spectacol("A1",8, 10),
                new Spectacol("A2",10, 11),
                new Spectacol("A3",9, 13),
                new Spectacol("A4",12, 13),
                new Spectacol("A5",14, 16),
                new Spectacol("A6",17, 19)
            };

            Ordoneaza(spectacole);

            List<Spectacol> raspuns = new List<Spectacol>();

            Spectacol ultimul = spectacole[0];
            raspuns.Add(ultimul);

            for(int i = 1; i < spectacole.Length; i++)
            {
                if( ultimul.sfarsit <= spectacole[i].inceput )
                {
                    ultimul = spectacole[i];
                    raspuns.Add(ultimul);
                }
            }
            foreach(Spectacol spectacol in raspuns)
                Console.Write(spectacol.nume+" ");

            Console.ReadKey();
        }

        private static void Ordoneaza(Spectacol[] spectacole)
        { }
    }
}
