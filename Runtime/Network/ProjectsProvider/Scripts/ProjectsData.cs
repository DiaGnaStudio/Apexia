namespace Projects.Provider.Data
{
    public class ProjectsData
    {
        public int id;
        public string name;
        public string country;
        public string city;
        public string address;

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Country: {country}, City: {city}, Address: {address}";
        }
    }
}