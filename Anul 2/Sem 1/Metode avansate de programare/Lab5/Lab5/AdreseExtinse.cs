using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class AdreseExtinse :Adrese
    {
        public List<string> locatie;
        public string email;
        public List<string> dateCompl;
        public AdreseExtinse(string nume, string numarTel,string email ):base(nume, numarTel)
        {
            this.email = email;
            this.tip = tipAdrese.adresaComplexa;
            locatie = new List<string>();
            dateCompl = new List<string>();
        }

        public void Add(string adr)
        {
            this.locatie.Add(adr);
        }
    }
}
