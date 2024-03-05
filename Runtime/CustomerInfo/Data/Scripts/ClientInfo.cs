namespace CustomerInfo.Data
{
    public class ClientInfo
    {
        public ClientInfo(int id, string firstName, string lastName, string email, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static ClientInfo Guest => new(-1, "New User", string.Empty, string.Empty, string.Empty);
    }
}