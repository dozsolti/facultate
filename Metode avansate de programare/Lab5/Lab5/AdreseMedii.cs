using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class AdreseMedii:Adrese
    {
        public List<string> locatie;
        public AdreseMedii(string nume, string numarTel): base(nume, numarTel)
        {
            tip = tipAdrese.adresaMedia;
            locatie = new List<string>();
        }
        public void Add(string local)
        {
            locatie.Add(local);
        }
    }
}
