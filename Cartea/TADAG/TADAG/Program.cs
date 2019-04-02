using System;

namespace TADAG
{
    //Enunt: generarea unui vector care contine doar numarul 10, folosind Alg Genetic

    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            Populatie populatie = new Populatie(10,3);
            populatie.Afisare();
            for (int i = 0; i < 1000000; i++)
                populatie.Actualizare();
            populatie.Afisare();
            Console.ReadKey();
        }
    }
}
