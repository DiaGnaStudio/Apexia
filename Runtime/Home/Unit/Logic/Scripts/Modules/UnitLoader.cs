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
            var state = GetState(data.state);

            return (data.id, new(name, area, floor, price, unitTypeCard, orientation, availability, state));

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
                    "1 Bedroom" => UnitType.bedroom_1,
                    "1 Bedroom + study" => UnitType.bedroom_1_studio,
                    "2 Bedroom" => UnitType.bedroom_2,
                    "2 Bedroom + study" => UnitType.bedroom_2_studio,
                    "2 Bedroom + maid" => UnitType.bedroom_2_maid,
                    _ => throw new ArgumentException(),
                };
            }

            State GetState(string state)
            {
                return state switch
                {
                    "Saleable" => State.Saleable,
                    "Unsaleble" => State.Unsaleble,
                    "Negotiable" => State.Negotiable,
                    _ => throw new ArgumentException(),
                };
            }
        }
    }
}