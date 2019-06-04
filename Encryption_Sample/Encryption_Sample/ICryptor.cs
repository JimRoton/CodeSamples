namespace Encryption_Sample
{
    public interface ICryptor
    {
        byte[] Encrypt(string StringToEncrypt);

        string Decrypt(byte[] BytesToDecrypt);
    }
}
