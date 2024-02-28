using Min_Max_Slider;
using SwitchPanel;
using System;
using System.Linq;
using Unit.Data;
using UnityEngine;
using UScreens;

namespace Unit.View.Components
{
    internal class UnitFilterPanel : UPanel
    {
        [SerializeField] private MinMaxSlider areaSlider;
        [SerializeField] private MinMaxSlider priceSlider;
        [SerializeField] private MinMaxSlider roiSlider;
        [SerializeField] private MinMaxSlider floorSlider;
        [SerializeField] private SwitchButtonsPanel typeSelected;
        [SerializeField] private SwitchButtonsPanel availabilitySelected;
        [SerializeField] private SwitchButtonsPanel orientationSelected;

        private readonly UnitFilter Filter = UnitFilter.All;

        public void SetData(Action<UnitFilter> onUpdate)
        {
            SetAreaAction();
            SetPriceAction();
            //SetROIAction();
            SetFloorAction();
            SetChangeType();
            SetChangeAvailability();
            //SetChangeOrientation();

            void SetAreaAction()
            {
                areaSlider.onValueChanged.AddListener(OnChange);

                void OnChange(float min, float max) =>
                    onUpdate.Invoke(Filter.UpdateArea(min, max));
            }

            void SetPriceAction()
            {
                priceSlider.onValueChanged.AddListener(OnChange);

                void OnChange(float min, float max) =>
                    onUpdate.Invoke(Filter.UpdatePrice(min, max));
            }

            //void SetROIAction()
            //{
            //    roiSlider.onValueChanged.AddListener(OnChange);

            //    void OnChange(float min, float max) =>
            //        onUpdate.Invoke(Filter.UpdateROI(min, max));
            //}

            void SetFloorAction()
            {
                floorSlider.onValueChanged.AddListener(OnChange);

                void OnChange(float min, float max) =>
                    onUpdate.Invoke(Filter.UpdateFloor(min, max));
            }

            void SetChangeType()
            {
                typeSelected.OnChangedMultiple.AddListener(OnChanged);

                void OnChanged(int[] selected) =>
                    onUpdate.Invoke(Filter.UpdateTypes(selected.Cast<UnitType>().ToArray())); //TODO: change Cast function
            }

            void SetChangeAvailability()
            {
                availabilitySelected.OnChangedMultiple.AddListener(OnChanged);

                void OnChanged(int[] selected) =>
                    onUpdate.Invoke(Filter.UpdateAvailabilities(selected.Cast<Availabilty>().ToArray())); //TODO: change Cast function
            }

            //void SetChangeOrientation()
            //{
            //    orientationSelected.OnChangedMultiple.AddListener(OnChanged);

            //    void OnChanged(int[] selected) =>
            //        onUpdate.Invoke(Filter.UpdateOrientation(selected.Cast<Orientation>().ToArray())); //TODO: change Cast function
            //}
        }
    }
}