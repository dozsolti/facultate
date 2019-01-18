using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Adrese
    {
        public tipAdrese tip;
        public string nume;
        public string numarTel;
        public Adrese(string nume, string numarTel)
        {
            this.nume = nume;
            this.numarTel = numarTel;
        }
    }
}
