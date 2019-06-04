using System;

namespace Encryption_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string blah = Test();

            ICryptor Cryptor = new AesCryptor(
                "Struct",
                "Development"
            );

            byte[] EncryptedBytes = Cryptor.Encrypt(
                "The quick brown fox jumps over the lazy dog."
            );

            Console.WriteLine(Cryptor.Decrypt(EncryptedBytes));
        }
    }
}
