namespace Auth.Provider.Data
{
    public class UserData
    {
        public string id;
        public string firstname;
        public string lastname;
        public string username;
        public string email;
        public bool isActive;
        public bool blocked;
        public string preferedLanguage;
        public string createdAt;
        public string updatedAt;

        public override string ToString()
        {
            return $"User Data:\n" +
                   $"ID: {id}\n" +
                   $"First Name: {firstname}\n" +
                   $"Last Name: {lastname}\n" +
                   $"Username: {username}\n" +
                   $"Email: {email}\n" +
                   $"Active: {isActive}\n" +
                   $"Blocked: {blocked}\n" +
                   $"Preferred Language: {preferedLanguage}\n" +
                   $"Created At: {createdAt}\n" +
                   $"Updated At: {updatedAt}\n";
        }
    }
}