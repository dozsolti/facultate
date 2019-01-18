using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1v2
{
    public abstract class Crypto
    {
        public Key encKey;
        public Key decKey;

        public string Encrypt(string text) => Hash(text, encKey);
        public string Decrypt(string code) => Hash(code, decKey);
        
        public string Hash(string from, Key key)
        {
            StringBuilder to = new StringBuilder();
            for (int i = 0; i < from.Length; i++)
                to[i] = key.Convert(from[i]);
            return to.ToString();
        }
    }
}
