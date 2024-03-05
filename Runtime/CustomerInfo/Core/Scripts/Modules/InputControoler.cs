using System;
using System.Text.RegularExpressions;

namespace CustomerInfo.Core.Module
{
    internal class InputControoler
    {
        private readonly EmailValidator emailValidator = new();
        private readonly PhoneValidator phoneValidator = new();
        private readonly NameValidator firstNameValidator = new();
        private readonly NameValidator lastNameValidator = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        private readonly Action<bool> OnChangeVerify;

        public InputControoler(Action<bool> onChangeVerify)
        {
            OnChangeVerify = onChangeVerify;
            onChangeVerify.Invoke(false);
        }

        public bool IsVerify { get; private set; } = false;

        public void ChangeFirstName(string value)
        {
            FirstName = value;
            firstNameValidator.ValidateName(value);
            CheckVerify();
        }

        public void ChangeLastName(string value)
        {
            LastName = value;
            lastNameValidator.ValidateName(value);
            CheckVerify();
        }

        public void ChangePhoneNumber(string value)
        {
            PhoneNumber = value;
            phoneValidator.ValidatePhoneNumber(value);
            CheckVerify();
        }

        public void ChangeEmail(string value)
        {
            Email = value;
            emailValidator.ValidateEmail(value);
            CheckVerify();
        }

        private void CheckVerify()
        {
            if (emailValidator.IsValid && phoneValidator.IsValid && firstNameValidator.IsValid && lastNameValidator.IsValid)
            {
                IsVerify = true;
                OnChangeVerify.Invoke(true);
            }
            else if (IsVerify)
            {
                IsVerify = false;
                OnChangeVerify.Invoke(false);
            }
        }

        internal class EmailValidator
        {
            /// <summary>
            /// Regular expression, which is used to validate an E-Mail address.
            /// </summary>
            public const string pattern =
                @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                  + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            public bool IsValid { get; private set; }

            public bool ValidateEmail(string value)
            {
                IsValid = !string.IsNullOrEmpty(value) && Regex.IsMatch(value, pattern);
                return IsValid;
            }
        }

        internal class PhoneValidator
        {
            public const string pattern = @"^\+?(\d{1,3})?[-. ]?\(?\d{3}\)?[-. ]?\d{3}[-. ]?\d{4}$";

            public bool IsValid { get; private set; }

            public bool ValidatePhoneNumber(string value)
            {
                IsValid = !string.IsNullOrEmpty(value) && Regex.IsMatch(value, pattern);

                return IsValid;
            }
        }

        internal class NameValidator
        {
            public const string pattern = @"^[a-zA-Z\s']{2,}$";

            public bool IsValid { get; private set; }

            public bool ValidateName(string value)
            {
                // Allow alphabets and spaces only, with a minimum length of 2 characters
                IsValid = !string.IsNullOrEmpty(value) && Regex.IsMatch(value, pattern);
                return IsValid;
            }
        }
    }
}