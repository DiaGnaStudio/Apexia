namespace Units.Provider.Data
{
    public class UnitData
    {
        public int id;
        public string name;
        public string area;
        public int floor;
        public string unit_type;
        public string direction;
        public string status;
        public string negotiationStatus;

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Area: {area}, Floor: {floor}, Unit Type: {unit_type}, Direction: {direction}, Status: {status}, State: {negotiationStatus}";
        }
    }
}