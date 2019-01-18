using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1
{
    public class Poly : Crypto
    {
        public Poly()
        {
            
        }

        public override void GenerateKeys()
        {
            int[] v = new int[26];
            for (int i = 0; i < v.Length; i++)
                v[i] = i;
            for(int i = v.Length - 1; i >= 1; i--)
            {
                int j = (new Random()).Next(i+1);
                int temp = v[i];
                v[i] = v[j];
                v[j] = temp;
            }
            encKey = new Dictionary<char, char>();
            for (int i = 0; i < 26; i++)
            {
                char current = (char)('a' + i);
                char other = (char)('a' + v[i]);
                encKey.Add(current, other);
            }
        }
        
    }
}
