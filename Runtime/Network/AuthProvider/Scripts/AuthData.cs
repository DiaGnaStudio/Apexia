namespace Auth.Provider.Data
{
    public class AuthData
    {
        public Data data;

        public struct Data
        {
            public string token;
            public UserData user;

            public override string ToString()
            {
                return $"Data:\n" +
                       $"Token: {token}\n" +
                       $"User: " + user.ToString();
            }
        }

        public override string ToString()
        {
            return $"Auth Data:\n" +
                   $"Data: {data}\n";
        }
    }
}