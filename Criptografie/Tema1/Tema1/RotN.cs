using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class RotN : Crypto
    {
        protected int n;
        public RotN()
        {
            n = (new Random()).Next(26);
            this.GenerateKeys();
        }

        public override void GenerateKeys()
        {
            encKey = new Dictionary<char, char>();
            decKey = new Dictionary<char, char>();
            /*for (int i = 0; i < 26; i++)
            {
                char current = (char)('a' + i);
                char other = (char)('a' + (i + n) % 26);

                encKey.Add(current, other);
                decKey.Add(other, current);
            }*/
            for (char current = 'a'; current <= 'z'; current++)
            {
                
                char other = (char)('a' + (current-'a' + n) % 26);

                encKey.Add(current, other);
                decKey.Add(other, current);
            }
        }
       
    }
}
