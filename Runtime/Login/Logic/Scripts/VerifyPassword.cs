namespace Login.Core
{
    internal class VerifyPassword
    {
        private const int MatchLenght = 8;

        public bool IsCorrect { get; private set; }

        public string Password { get; private set; }

        internal bool IsPassword(string password)
        {
            IsCorrect = password.Length >= MatchLenght;
            Password = password;
            return IsCorrect;
        }
    }
}