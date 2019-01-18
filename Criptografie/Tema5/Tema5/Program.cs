using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Generate Keys
                 * 1.1 generate b {X}
                 * 1.2 get M {X}
                 * 1.3 get W {X}
                 * 1.4 get Pirmutation {X}
                 * 1.5 calc A {X}
                 * 1.6 set publicKey = a {X}
                 * 1.7 set privateKey = (Pirmutation, M, W,(b1, b2,... ,bn)) {X}
             * 2. Encrypt {X}
             * 3. Decrypt {X}
            */
            string message = "abc";

            Key key = MerkleKeyFactory.GenerateKey(6,new int[] { 12, 17, 33, 74, 157, 316});

            int cipherText = MerkleCryptor.Encrypt(message, key);
            Console.WriteLine("Encrypt( 1,0,1,1,0,1 ): " + cipherText);
            
            byte[] decryptedCipher = MerkleCryptor.Decrypt(cipherText, key);
            Console.Write("Decrypted( {0} ): ",cipherText);
            foreach (byte x in decryptedCipher)
                Console.Write(x);

            Console.WriteLine();
            Console.ReadKey();
        }
        
    }
}
