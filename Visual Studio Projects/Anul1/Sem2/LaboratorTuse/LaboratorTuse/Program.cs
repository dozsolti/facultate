using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorTuse
{
    class Program
    {
        static List<Angajat> angajati;
        static void Main(string[] args)
        {
            TextReader dl = new StreamReader(@"./file.txt");
            string buffer;
            angajati = new List<Angajat>();
            while ((buffer = dl.ReadLine()) != null)
            {
                Angajat ang = new Angajat(buffer.Split(' '));
                angajati.Add(ang);
            }
            dl.Close();
            TextWriter outputAlfa = new StreamWriter(@"./outputAlfa.txt");
            
            angajati.Sort(delegate (Angajat a,Angajat b) { return a.compare(b); });
            foreach (Angajat item in angajati)
                outputAlfa.WriteLine(item.ToString());

            outputAlfa.Close();
            
            TextWriter outputVechi = new StreamWriter(@"./outputOld.txt");
            angajati.Sort(delegate (Angajat a,Angajat b) { return a.data.CompareTo(b.data); });
            foreach (Angajat item in angajati)
            {
                outputVechi.Write(item.ToString());
                TimeSpan dif = DateTime.Now - item.data;
                float luni = 0;
                if (dif.Days > 30)
                    luni = dif.Days / 30;
                outputVechi.Write(" Este angajat de {0} (de) luni {1} (de) zile",luni, dif.Days%30);
                outputVechi.WriteLine();
            }
            outputVechi.Close();
            Console.ReadKey();
        }
        static void Add(Angajat a)
        {
            angajati.Add(a);
        }
        static void Remove(Angajat a)
        {
            angajati.Remove(a);
        }
    }
}
