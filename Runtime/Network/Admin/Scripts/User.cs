namespace Admin.Provider.Data
{
    public class User
    {
        public int id;
        public string firstname;
        public string lastname;
        public string fullname;
        public string email;
        public string username;
        public Avatar avatar;

        public override string ToString()
        {
            return $"ID: {id}\n" +
                   $"First Name: {firstname}\n" +
                   $"Last Name: {lastname}\n" +
                   $"Full Name: {fullname}\n" +
                   $"Email: {email}\n" +
                   $"Username: {username}\n" +
                   $"Avatar URL: {avatar.url}\n" +
                   $"Avatar Extension: {avatar.ext}\n" +
                   $"Avatar Size: {avatar.size}\n" +
                   $"Avatar Width: {avatar.width}\n" +
                   $"Avatar Height: {avatar.height}";
        }

        public class Avatar
        {
            public string url;
            public string ext;
            public float size;
            public int width;
            public int height;
        }
    }
}