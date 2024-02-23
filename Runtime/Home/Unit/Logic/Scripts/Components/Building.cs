using System;
using System.Collections.Generic;
using Unit.SharedTypes;
using UnityEngine;

namespace Unit.Logic.Components
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private Unit[] units;

        private readonly List<Unit> filterList = new();

        public void InitializeUnits(Action<UnitCard> onSelect)
        {
            foreach (var unit in units)
                unit.SetSelectAction(onSelect);
        }

        public void ApplyFilter(UnitFilter filter)
        {
            filterList.Clear();
            foreach (var unit in units)
            {
                if (!filter.IsTypeCountins(unit.Card.UnitTypeCard.Type)) continue;
                if (!filter.IsOrientationCountins(unit.Card.Orientation)) continue;
                if (!filter.IsAvailabilitiesCountins(unit.Card.Availability)) continue;
                if (!(unit.Card.Area >= filter.Area.x && unit.Card.Area <= filter.Area.y)) continue;
                if (!(unit.Card.Price >= filter.Price.x && unit.Card.Price <= filter.Price.y)) continue;

                filterList.Add(unit);
            }

            foreach (var unit in units)
                unit.Highlight(false);

            foreach (var unit in filterList)
                unit.Highlight(true);
        }

        public void GoToBalcony(UnitCard card) =>
            GetUnit(card).GoToBalcony();

        public void UnSelectUnit(UnitCard card) =>
            GetUnit(card).UnSelect();

        private Unit GetUnit(UnitCard card)
        {
            foreach (var unit in units)
                if (unit.Card == card)
                    return unit;
            return null;
        }
    }
}