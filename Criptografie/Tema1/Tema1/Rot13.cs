using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Rot13 : RotN
    {
        public Rot13()
        {
            this.n = 13;
            this.GenerateKeys();
            decKey = null;
        }
        new public string Decrypt(string code)
        {
            return base.Encrypt(code);
        }
    }
}
