using System;
using System.Collections.Generic;
using Unit.Data;
using UnityEngine;

namespace Unit.Logic.Components
{
    internal class Building : MonoBehaviour
    {
        private Unit[] units;
        private readonly List<Unit> filterList = new();

        private void Awake()
        {
            units = GetComponentsInChildren<Unit>();
        }

        public void InitializeUnits(Action<UnitData, int, string> onSelect)
        {
            foreach (var unit in units)
                unit.SetSelectAction(onSelect);
        }

        public void LoadUnits(Func<string, UnitData> dataGetter)
        {
            foreach (var unit in units)
                unit.LoadData(dataGetter);
        }

        public void ApplyFilter(UnitFilter filter)
        {
            filterList.Clear();
            foreach (var unit in units)
            {
                if (!unit.IsInitialize) continue;
                if (unit.Data.UnitTypeCard == null) continue; // TODO: remove after get all data from server
                if (!filter.IsTypeCountins(unit.Data.UnitTypeCard.Type)) continue;
                if (!filter.IsOrientationCountins(unit.Data.Orientation)) continue;
                if (!filter.IsAvailabilitiesCountins(unit.Data.Availability)) continue;
                if (!(unit.Data.Area >= filter.Area.x && unit.Data.Area <= filter.Area.y)) continue;
                if (!(unit.Data.Price >= filter.Price.x && unit.Data.Price <= filter.Price.y)) continue;

                filterList.Add(unit);
            }

            foreach (var unit in units)
                unit.Highlight(false);

            foreach (var unit in filterList)
                unit.Highlight(true);
        }

        public void GoToBalcony(UnitData card) =>
            GetUnit(card).GoToBalcony();

        public void UnSelectUnit(UnitData card) =>
            GetUnit(card).UnSelect();

        private Unit GetUnit(UnitData data)
        {
            foreach (var unit in units)
                if (unit.Data.Equals(data))
                    return unit;
            return null;
        }
    }
}