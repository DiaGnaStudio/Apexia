using System;
using System.Linq;
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

        private readonly Storage<int, UnitData> unitStorage = new();

        private readonly Building building;
        private readonly FilterHandler filter;

        private readonly UnitCamera camera;

        private BookmarkHandler bookmark;

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

            void CompleteLoad((int id, UnitData data)[] infos)
            {
                foreach (var (id, data) in infos)
                {
                    if (data.State == State.Saleable)
                    {
                        paymentLoaderAPI.Load(id, LoadInstallment);

                        void LoadInstallment(UnitInstallmentsData installmentsData) =>
                            data.SetPrice(installmentsData.UnitInfo.Price);
                    }

                    unitStorage.Add((id, data));
                }

                building.LoadUnits(unitStorage.Get);
            }
        }

        public void SelectUnit(Action<UnitData, UnitInstallmentsData, Sprite> onSelect)
        {
            building.InitializeUnits(Select);

            void Select(UnitData unitData, int code, int id)
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

        public void SetCameraPoint() =>
            camera.SetPoints();

        public bool IsBookmarkEnable() =>
            bookmark.IsEnable();

        internal void InitializeBookmark(Func<int> getClientId) => 
            bookmark = new(getClientId);

        public void SetActiveBuilding(bool value) => 
            building.gameObject.SetActive(value);
    }
}