using System;

namespace Tema1v2
{
    public partial class KeyFactory
    {
        public char[] alphabet;
        private static KeyFactory instance;
        public static KeyFactory InstanceABC {
            get {
                if (instance == null)
                    instance = new KeyFactory();
                instance.alphabet = new char[] { 'a', 'b', 'c' };
                return instance;
            }
        }
        public static KeyFactory InstanceE
        {
            get
            {
                if (instance == null)
                    instance = new KeyFactory();
                instance.alphabet = new char[] { 'e', 'e', 'e' };
                return instance;
            }
        }
        private KeyFactory() { }

        public Key GenerateEncryptRotN(int n)
        {
            throw new NotImplementedException();
        }

        public Key GenerateDecryptRotN(int n)
        {
            throw new NotImplementedException();
        }
    }
}