using System;
using System.Collections.Generic;

namespace Tema1v2
{
    public class Key
    {
        private Dictionary<char, char> key;

        public void Set(char[] keys, char[] values)
        {
            for (int i = 0; i < keys.Length; i++)
                key.Add(keys[i], values[i]);
        }
        public char Convert(char v)
        {
            return key[v];
        }
    }
}