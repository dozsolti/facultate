using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class AdreseSimple:Adrese
    {
        public AdreseSimple(string nume, string numarTel) : base(nume, numarTel)
        {
            tip = tipAdrese.adresaSimpla;
        }
    }
}
