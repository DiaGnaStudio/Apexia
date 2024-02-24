namespace Unit.Data
{
    public struct UnitData
    {
        public UnitData(string name, int area, int floor, int price, UnitTypeCard unitTypeCard, Orientation orientation, Availabilty availability)
        {
            Name = name;
            Area = area;
            Floor = floor;
            Price = price;
            UnitTypeCard = unitTypeCard;
            Orientation = orientation;
            Availability = availability;
        }

        public string Name { private set; get; }
        public int Area { private set; get; }
        public int Floor { private set; get; }
        public int Price { private set; get; }
        public UnitTypeCard UnitTypeCard { private set; get; }
        public Orientation Orientation { private set; get; }
        public Availabilty Availability { private set; get; }

        public static UnitData DEFAULT => new() { Name = "DEFAULT" };
    }
}