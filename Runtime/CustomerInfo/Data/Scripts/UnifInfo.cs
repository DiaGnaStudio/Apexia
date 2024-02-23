namespace CustomerInfo.Data
{
    public struct UnifInfo
    {
        public UnifInfo(string id, string unitName, string unitType, int floor, int price, int area)
        {
            Id = id;
            UnitName = unitName;
            UnitType = unitType;
            Floor = floor;
            Price = price;
            Area = area;
        }

        public string Id { get; private set; }
        public string UnitName { get; private set; }
        public string UnitType { get; private set; }
        public int Floor { get; private set; }
        public int Price { get; private set; }
        public int Area { get; private set; }

    }
}
