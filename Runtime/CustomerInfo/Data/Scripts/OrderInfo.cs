namespace CustomerInfo.Data
{
    public class OrderInfo
    {
        public OrderInfo(int id, string unitName, string unitType, int floor, string price, int area)
        {
            Id = id;
            UnitName = unitName;
            UnitType = unitType;
            Floor = floor;
            Price = price;
            Area = area;
        }

        public int Id { get; private set; }

        public string UnitName { get; private set; }

        public string UnitType { get; private set; }

        public int Floor { get; private set; }

        public string Price { get; private set; }

        public int Area { get; private set; }
    }
}