using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public abstract class Crypto
    {
        protected Crypto()
        {
            this.GenerateKeys();
        }

        protected Dictionary<char, char> encKey;
        protected Dictionary<char, char> decKey;

        public abstract void GenerateKeys();

        public string Encrypt(string text)
        {
            StringBuilder code = new StringBuilder(text);
            for (int i = 0; i < text.Length; i++)
                code[i] = encKey[text[i]];
            return code.ToString();
            /*string code = "";
            for (int i = 0; i < text.Length; i++)
                code += encKey[text[i]];
            return code;*/
        }
        public string Decrypt(string code)
        {
            string text = "";
            for (int i = 0; i < code.Length; i++)
                text += decKey[code[i]];
            return text;
        }
    }
}
