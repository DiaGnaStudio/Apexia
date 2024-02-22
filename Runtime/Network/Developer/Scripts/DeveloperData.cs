using System.Collections.Generic;

namespace Developer.Provider.Data
{
    public class DeveloperData
    {
        public int id;
        public string name;
        public string commercial_name;
        public string subdomain;

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Commercial Name: {commercial_name}, Subdomain: {subdomain}";
        }
    }
}