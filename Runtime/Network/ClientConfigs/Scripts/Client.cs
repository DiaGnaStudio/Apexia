using System;
namespace ClientConfigs.Provider.Data
{
    public class Client
    {
        public int id;
        public string first_name;
        public string last_name;
        public string email;
        public string phone;
        public DateTime created_at;
        public DateTime updated_at;

        public override string ToString() =>
            $"Client ID: {id}\nName: {first_name} {last_name}\nEmail: {email}\nPhone: {phone}\nCreated At: {created_at}\nUpdated At: {updated_at}";
    }

    public class ClientResponse
    {
        public int status;
        public Client client;
    }
}