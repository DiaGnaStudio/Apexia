using Codice.CM.Common.Serialization;

namespace Units.Provider.Data
{
    public class UnitData
    {
        public string id;
        public string name;
        public string area;
        public int floor;
        public string unit_type;
        public string direction;
        public string status;
        public string state;

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Area: {area}, Floor: {floor}, Unit Type: {unit_type}, Direction: {direction}, Status: {status}";
        }
    }
}