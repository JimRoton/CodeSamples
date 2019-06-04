using System;
using System.Text;

namespace Encryption_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string Data = "The quick brown fox jumps over the lazy dog.";

            // create cryptor
            ICryptor Cryptor = new AesCryptor(
                "Struct",
                "Development"
            );

            // write the starting string
            Console.WriteLine(string.Format("StartingString: {0}\n", Data));

            // encrypt string to bytes
            byte[] EncryptedBytes = Cryptor.Encrypt(Data);

            // write the encrypted data
            Console.WriteLine(string.Format("EncryptedData: {0}\n", Encoding.UTF8.GetString(EncryptedBytes)));

            // decrypt bytes to string
            string DecryptedString = Cryptor.Decrypt(EncryptedBytes);

            // write the decrypted string
            Console.WriteLine(string.Format("DecryptedString: {0}", DecryptedString));
        }
    }
}
