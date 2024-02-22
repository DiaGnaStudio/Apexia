using System;
using System.Text.RegularExpressions;

namespace Login.Core
{
    internal class VerifyEmail
    {
        /// <summary>
        /// Regular expression, which is used to validate an E-Mail address.
        /// </summary>
        public const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        public bool IsCorrect { get; private set; }

        public string Email { get; private set; }

        /// <summary>
        /// Checks whether the given Email-Parameter is a valid E-Mail address.
        /// </summary>
        /// <param name="email">Parameter-string that contains an E-Mail address.</param>
        /// <returns>True, wenn Parameter-string is not null and contains a valid E-Mail address;
        /// otherwise false.</returns>
        public bool IsEmail(string email)
        {
            IsCorrect = email != null && Regex.IsMatch(email, MatchEmailPattern);
            Email = email;
            return IsCorrect;
        }
    }
}