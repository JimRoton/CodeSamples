using Struct.Core.Extensions;

using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Encryption_Sample
{
    public class AesCryptor : ICryptor
    {
        /// <summary>
        /// Aes Encryptor
        /// </summary>
        private readonly Aes Aes;

        /// <summary>
        /// This is the constructor for the AES
        /// cryptor. EncryptionKey and SaltKey
        /// are expected and must be at least
        /// one character each.
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="Salt"></param>
        public AesCryptor(string EncryptionKey, string SaltKey)
        {
            // check required password
            if (EncryptionKey.IsNullEmptyOrWhiteSpace())
                throw new ArgumentNullException("EncryptionKey");

            // check required salt key
            else if (SaltKey.IsNullEmptyOrWhiteSpace())
                throw new ArgumentNullException("SaltKey");

            // create the encryptor & decryptor
            this.Aes = Aes.Create();

            // set the iv and the key
            this.Aes.Key = EncryptionKey.ConvertToCryptoKey(32);
            this.Aes.IV = SaltKey.ConvertToCryptoKey(16);

            // set the padding size (might not need)
            this.Aes.Padding = PaddingMode.PKCS7;

            // ciphermode is cbc which sets initial values
            // based on xor of salt key.
            this.Aes.Mode = CipherMode.CBC;
        }

        /// <summary>
        /// This method is used to encrypt a string
        /// using AES encryption.
        /// </summary>
        /// <param name="StringToEncrypt">String</param>
        /// <returns>Encrypted Bytes</returns>
        public byte[] Encrypt(string StringToEncrypt)
        {
            // if there's nothing to encrypt
            // just return an empty array
            if (StringToEncrypt.IsNullEmptyOrWhiteSpace())
                return new byte[0];

            // we should create the new memory stream
            // and crypto stream first. If this fails
            // we should bubble up the error.
            MemoryStream MS = new MemoryStream();
            CryptoStream CS = CS = new CryptoStream(
                MS,
                this.Aes.CreateEncryptor(),
                CryptoStreamMode.Write
            );

            try
            {
                // encrypt the string into the memory stream
                CS.Write(Encoding.UTF8.GetBytes(StringToEncrypt), 0, StringToEncrypt.Length);
                CS.FlushFinalBlock();

                return MS.ToArray();
            }
            finally
            {
                // close the streams
                if (CS != null) CS.Close();
                if (MS != null) MS.Close();
            }
        }

        /// <summary>
        /// This method is used to decrypt previously
        /// encrypted bytes back into a string.
        /// </summary>
        /// <param name="BytesToDecrypt">Encrypted Bytes</param>
        /// <returns>Decrypted String</returns>
        public string Decrypt(byte[] BytesToDecrypt)
        {
            // make sure we have something
            BytesToDecrypt = BytesToDecrypt.ToArrayOrEmpty();

            // we should create the new memory stream
            // and crypto stream first. If this fails
            // we should bubble up the error.
            MemoryStream MS = new MemoryStream();
            CryptoStream CS = new CryptoStream(
                MS,
                this.Aes.CreateDecryptor(),
                CryptoStreamMode.Write
            );

            try
            {
                CS.Write(BytesToDecrypt, 0, BytesToDecrypt.Length);
                CS.FlushFinalBlock();

                // return the string
                return Encoding.UTF8.GetString(MS.ToArray());
            }
            finally
            {
                // close the streams
                if (MS != null) MS.Close();
                if (CS != null) CS.Close();
            }
        }
    }
}
