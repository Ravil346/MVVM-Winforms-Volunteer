using BuisnessLogic.Models.Request;
using BuisnessLogic.Models.Result;
using BuisnessLogic.Validators;
using Data.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{
    public class PasswordManager(PasswordSaltOptions options) : ISafety, IDisposable
    {
        private PasswordValidator? _validator;
        public bool Compare()
        {
            _validator = new PasswordValidator(true, true);

            var validationResult = _validator.Validate(options!);

            if (!validationResult.IsValid) throw new ArgumentNullException();

            var hash = GetSaltedHashedPassword(options!.Password, options.Salt);

            return hash.Equals(options.Hash);
        }
        public SaltResultModel Salt(uint length)
        {
            _validator = new PasswordValidator();

            var validationResult = _validator.Validate(options!);

            if (!validationResult.IsValid) throw new ArgumentNullException(nameof(options.Password));

            using (var generator = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[(int)length];

                generator.GetBytes(bytes);

                string salt = Convert.ToBase64String(bytes);

                string saltedhashedPassword = GetSaltedHashedPassword(options!.Password, salt);

                return new SaltResultModel(saltedhashedPassword, salt);
            }
        }
        public void Dispose()
        {
            _validator = null;
        }
        private string GetSaltedHashedPassword(string password, string salt)
        {
            string saltedPassword = string.Concat(password, salt);

            byte[] saltedPasswordBytes = Encoding.Unicode.GetBytes(saltedPassword);

            SHA256 sha = SHA256.Create();

            byte[] saltedPasswordHashBytes = sha.ComputeHash(saltedPasswordBytes);

            string result = Convert.ToBase64String(saltedPasswordHashBytes);

            return result;
        }
    }
}
