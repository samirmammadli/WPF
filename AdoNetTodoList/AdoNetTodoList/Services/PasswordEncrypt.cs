using System;
using System.Security.Cryptography;

namespace AdoNetTodoList.Services
{
    class PasswordEncryptor
    {
        static private Random rnd = new Random();
        public string PasswordHash { get; private set; }
        public string Salt { get; private set; }
        public int Iterations { get; private set; }

        public PasswordEncryptor(string password)
        {
            EncryptPassword(password);
        }

        private void EncryptPassword(string password)
        {
            Iterations = rnd.Next(20, 100);
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var PBKDF2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var passHash = PBKDF2.GetBytes(38);

            PasswordHash = Convert.ToBase64String(passHash);
            Salt = Convert.ToBase64String(salt);
        }

        static public bool CheckPassword(string enteredPass, string passHashFromDB, string saltFromDb, int iterations)
        {
            var salt = Convert.FromBase64String(saltFromDb);
            var PBKDF2 = new Rfc2898DeriveBytes(enteredPass, salt, iterations);
            var passHash = PBKDF2.GetBytes(38);

            var enteredPassHash = Convert.ToBase64String(passHash);
            return enteredPassHash == passHashFromDB;
        }
    }
}
