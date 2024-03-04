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
        private readonly UnitPaymentLoader paymentLoaderAPI = new();

        private readonly UnitTypeRepo unitTypeStorage;
        private readonly UnitMapRepo unitMapStorage;

        private readonly Building building;
        private readonly FilterHandler filter;

        private UnitCamera camera;

        public UnitController()
        {
            camera = UnitCamera.LoadInstance;
            camera.Initialize();

            unitTypeStorage = UnitTypeRepo.PreLoad;
            unitMapStorage = UnitMapRepo.PreLoad;
            building = Object.FindObjectOfType<Building>(true);
            filter = new FilterHandler(building.ApplyFilter);

            loaderAPI = new(unitTypeStorage.Get);
            loaderAPI.LoadAll(CompleteLoad);

            void CompleteLoad((string id, UnitData data)[] infos)
            {
                building.LoadUnits(Get);

                foreach (var (id, data) in infos)
                {
                    if (data.State == State.Saleable)
                    {
                        paymentLoaderAPI.Load(id, LoadInstallment);

                        void LoadInstallment(UnitInstallmentsData installmentsData)
                        {
                            data.SetPrice(installmentsData.UnitInfo.Price);
                        }
                    }
                }

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

            void Select(UnitData unitData, int code, string id)
            {
                var map = unitMapStorage.Get(code, unitData.Floor);

                if (unitData.State == State.Saleable)
                    paymentLoaderAPI.Load(id, LoadInstallment);
                else
                    onSelect.Invoke(unitData, UnitInstallmentsData.Empty, map);

                void LoadInstallment(UnitInstallmentsData installmentsData)
                {
                    onSelect.Invoke(unitData, installmentsData, map);
                }
            }
        }

        public void GoToBalcony(UnitData card) =>
            building.GoToBalcony(card);

        public void UnSelectUnit(UnitData card) =>
            building.UnSelectUnit(card);

        public void UpdateFilter(UnitFilter filter) =>
            this.filter.Update(filter);

        public void Show() => 
            camera.SetPoints();
    }
}