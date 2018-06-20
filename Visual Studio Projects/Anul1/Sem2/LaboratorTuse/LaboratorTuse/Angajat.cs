using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorTuse
{
    class Angajat:IAngajat
    {
        public string nume;
        public string prenume;
        public DateTime data;

        public Angajat(string[] v)
        {
            this.nume = v[0];
            this.prenume = v[1];
            int zi = int.Parse(v[2].Split('.')[0]);
            int luna = int.Parse(v[2].Split('.')[1]);
            int an = int.Parse(v[2].Split('.')[2]);
            this.data = new DateTime(an,luna,zi);
        }
        public override string ToString()
        {
            return this.nume + " " + this.prenume + " " + this.data.ToShortDateString();
        }

        public int compare(Angajat obj)
        {
            if(this.nume == obj.nume)
                return this.prenume.CompareTo(obj.prenume);
            return this.nume.CompareTo(obj.nume);
        }
    }

    internal interface IAngajat
    {
        int compare(Angajat a);
    }
}
