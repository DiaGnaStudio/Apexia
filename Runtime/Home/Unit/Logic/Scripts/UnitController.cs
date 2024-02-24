using System;
using Unit.Data;
using Unit.Logic.Assets;
using Unit.Logic.Components;
using Unit.Logic.Module;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Unit.Logic
{
    public class UnitController
    {
        private readonly UnitLoader loaderAPI;

        private readonly UnitTypeRepo unitTypeStorage;
        private readonly UnitMapRepo unitMapStorage;

        private readonly Building building;
        private readonly FilterHandler filter;

        public UnitController()
        {
            unitTypeStorage = UnitTypeRepo.PreLoad;
            unitMapStorage = UnitMapRepo.PreLoad;
            building = Object.FindObjectOfType<Building>();
            filter = new FilterHandler(building.ApplyFilter);

            loaderAPI = new(unitTypeStorage.Get);
            loaderAPI.LoadAll(CompleteLoad);

            void CompleteLoad((string id, UnitData data)[] infos)
            {
                building.LoadUnits(Get);

                UnitData Get(string id)
                {
                    foreach (var info in infos)
                        if (info.id == id)
                            return info.data;

                    Debug.Log($"The unit is not loaded! (Unit id = {id})");
                    return UnitData.DEFAULT;
                }
            }
        }

        public void SelectUnit(Action<UnitData, UnitInstallmentsData, Sprite> onSelect)
        {
            building.InitializeUnits(Select);

            void Select(UnitData data, int code, string id)
            {
                var map = unitMapStorage.Get(code, data.Floor);

                onSelect.Invoke(data, new(), map);
            }
        }

        public void GoToBalcony(UnitData card) =>
            building.GoToBalcony(card);

        public void UnSelectUnit(UnitData card) =>
            building.UnSelectUnit(card);

        public void UpdateFilter(UnitFilter filter) =>
            this.filter.Update(filter);
    }
}