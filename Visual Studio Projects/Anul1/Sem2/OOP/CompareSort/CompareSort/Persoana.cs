using System;
using System.Collections;
namespace CompareSort
{
    internal class Persoana : IComparer
    {
        public string nume;
        public int varsta;

        public Persoana(string nume, int varsta)
        {
            this.nume = nume;
            this.varsta = varsta;
        }

        public int Compare(object x, object y)
        {
            Persoana pers1 = x as Persoana;
            Persoana pers2 = y as Persoana;
            //if(pers1.nume>pers2.nume)
            return String.Compare(pers1.nume, pers2.nume);

        }
        /*
        public int CompareTo(object obj)
        {
            Persoana other = obj as Persoana;
            return String.Compare(other.nume,this.nume);
        }*/
    }
}