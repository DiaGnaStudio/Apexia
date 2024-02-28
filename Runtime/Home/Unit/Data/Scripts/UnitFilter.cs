using UnityEngine;

namespace Unit.Data
{
    public class UnitFilter
    {
        public UnitFilter()
        {
        }

        public UnitFilter(Vector2 area, Vector2 price, Vector2 floor, UnitType[] types, Availabilty[] availabilties)
        {
            Area = area;
            Price = price;
            Floor = floor;
            Types = types;
            Availabilties = availabilties;
        }

        public Vector2 Area { get; private set; }
        public Vector2 Price { get; private set; }
        //public Vector2 ROI { get; private set; }
        public Vector2 Floor { get; private set; }
        public UnitType[] Types { get; private set; } = new UnitType[0];
        public Availabilty[] Availabilties { get; private set; } = new Availabilty[0];
        //public Orientation[] Orientations { get; private set; } = new Orientation[0];

        public static UnitFilter All => new(new(float.MinValue, float.MaxValue),
                                            new(float.MinValue, float.MaxValue),
                                            new(float.MinValue, float.MaxValue),
                                            new UnitType[4] { UnitType.Studio, UnitType.bedroom_1, UnitType.bedroom_2, UnitType.bedroom_3 },
                                            new Availabilty[4] { Availabilty.Sold, Availabilty.Reserved, Availabilty.Available, Availabilty.Unavailable });

        public UnitFilter UpdateArea(float min, float max)
        {
            Area = new Vector2(min, max);
            return this;
        }

        public UnitFilter UpdatePrice(float min, float max)
        {
            Price = new Vector2(min, max);
            return this;
        }

        //public UnitFilter UpdateROI(float min, float max)
        //{
        //    ROI = new Vector2(min, max);
        //    return this;
        //}

        public UnitFilter UpdateFloor(float min, float max)
        {
            Floor = new Vector2(min, max);
            return this;
        }

        public UnitFilter UpdateAvailabilities(Availabilty[] availabilties)
        {
            Availabilties = availabilties;
            return this;
        }

        //public UnitFilter UpdateOrientation(Orientation[] orientations)
        //{
        //    Orientations = orientations;
        //    return this;
        //}

        public UnitFilter UpdateTypes(UnitType[] unitTypes)
        {
            Types = unitTypes;
            return this;
        }

        public bool IsTypeCountins(UnitType type)
        {
            for (int i = 0; i < Types.Length; i++)
                if (Types[i] == type)
                    return true;

            return false;
        }

        //public bool IsOrientationCountins(Orientation orientation)
        //{
        //    for (int i = 0; i < Orientations.Length; i++)
        //        if (Orientations[i] == orientation)
        //            return true;

        //    return false;
        //}

        public bool IsAvailabilitiesCountins(Availabilty availability)
        {
            for (int i = 0; i < Availabilties.Length; i++)
                if (Availabilties[i] == availability)
                    return true;

            return false;
        }
    }
}