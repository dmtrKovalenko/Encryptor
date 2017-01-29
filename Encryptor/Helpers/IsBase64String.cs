using System;
using System.Globalization;
using System.Windows.Controls;

namespace Encryptor.Helpers
{
    class IsBase64String : ValidationRule
    {
        private const string validationMessage = "Decrypted text must be a valid base 64 string";

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var base64String = value as string;

            if (base64String == null || base64String.Length < 128
                || base64String.Length % 4 != 0 || base64String.Contains("\t")
                || base64String.Contains("\r") || base64String.Contains("\n"))
            {
                return new ValidationResult(false, validationMessage);
            }

            try
            {
                Convert.FromBase64String(base64String);
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                // Handle the exception
            }

            return new ValidationResult(false, validationMessage);

        }
    }
}
