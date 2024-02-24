using System;
using System.Linq;
using Unit.Data;
using Units.Provider;
using UnityEngine;

namespace Unit.Logic.Module
{
    internal class UnitLoader
    {
        private readonly Func<UnitType, UnitTypeCard> GetUnitType;

        public UnitLoader(Func<UnitType, UnitTypeCard> getUnitType)
        {
            GetUnitType = getUnitType;
        }

        public void Load(int id, Action<(string, UnitData)> onLoad)
        {
            UnitServices.GetById(id, Get, Error);

            void Get(Units.Provider.Data.UnitData data)
            {
                onLoad.Invoke(Convert(data));
            }

            void Error(string message) =>
                Debug.LogError(message);
        }

        public void LoadAll(Action<(string, UnitData)[]> onLoad)
        {
            UnitServices.GetAll(Get, Error);

            void Get(Units.Provider.Data.UnitData[] datas)
            {
                (string, UnitData)[] infos = datas.Select(data => Convert(data)).ToArray();

                onLoad.Invoke(infos);
            }

            void Error(string message) =>
                Debug.LogError(message);
        }

        private (string, UnitData) Convert(Units.Provider.Data.UnitData data)
        {
            var name = data.name;
            var area = int.Parse(data.area);
            var floor = data.floor;
            var price = 0;
            var unitTypeCard = GetUnitType(GetType(data.unit_type));
            var orientation = GetOrientation(data.direction);
            var availability = GetAvailabilty(data.status);

            return (data.id, new(name, area, floor, price, unitTypeCard, orientation, availability));

            Orientation GetOrientation(string direction)
            {
                return direction switch
                {
                    "East" => Orientation.East,
                    "West" => Orientation.West,
                    "South" => Orientation.South,
                    "North" => Orientation.North,
                    _ => Orientation.None,
                };
            }

            Availabilty GetAvailabilty(string status)
            {
                return status switch
                {
                    "Sold" => Availabilty.Sold,
                    "Reserved" => Availabilty.Reserved,
                    "Available" => Availabilty.Available,
                    "Unavailable" => Availabilty.Unavailable,
                    _ => throw new ArgumentException(),
                };
            }

            UnitType GetType(string unit_type)
            {
                return unit_type switch
                {
                    "Studio" => UnitType.Studio,
                    "1 Bedroom" or "1 Bedroom + study" or "1 Bedroom + maid" => UnitType.bedroom_1,
                    "2 Bedroom" or "2 Bedroom + study" or "2 Bedroom + maid" => UnitType.bedroom_2,
                    "3 Bedroom" or "3 Bedroom + study" or "3 Bedroom + maid" => UnitType.bedroom_3,
                    _ => throw new ArgumentException(),
                };
            }
        }
    }
}