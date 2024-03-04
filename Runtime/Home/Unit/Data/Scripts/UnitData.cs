namespace Unit.Data
{
    public class UnitData
    {
        public UnitData(int id, string name, int area, int floor, int price, UnitTypeCard unitTypeCard, Orientation orientation, Availabilty availability, State state)
        {
            Id = id;
            Name = name;
            Area = area;
            Floor = floor;
            Price = price;
            UnitTypeCard = unitTypeCard;
            Orientation = orientation;
            Availability = availability;
            State = state;
        }

        public int Id { get; private set; }
        public string Name { private set; get; }
        public int Area { private set; get; }
        public int Floor { private set; get; }
        public int Price { private set; get; }
        public UnitTypeCard UnitTypeCard { private set; get; }
        public Orientation Orientation { private set; get; }
        public Availabilty Availability { private set; get; }
        public State State { get; private set; }

        public static UnitData DEFAULT => new(0, "DEFAULT", 0, 0, 0, null, Orientation.West, Availabilty.Unavailable, State.Negotiable);

        public void SetPrice(int value) =>
            Price = value;
    }
}