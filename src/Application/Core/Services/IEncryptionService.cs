namespace Application.Core.Services
{
    public interface IEncryptionService
    {
        public string CreatePasswordHash(string password, string saltKey);

        public string EncryptText(string plainText);

        public string DecryptText(string cipherText);
    }
}