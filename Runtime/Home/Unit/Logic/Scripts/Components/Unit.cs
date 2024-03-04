using System;
using UCamSystem;
using Unit.Data;
using UnityEngine;

namespace Unit.Logic.Components
{
    internal class Unit : MonoBehaviour
    {
        [SerializeField] private string unitId;
        [SerializeField, Range(1, 12)] private int unitCode;

        [Header("Components")]
        [SerializeField] private UCamPoint ballconyCamPoint;
        [SerializeField] private UnitBorderRenderer borderRenderer;
        [SerializeField] private UnitBodyRenderer bodyRenderer;
        [SerializeField] private ObjectSelect objectSelect;

        private const float DOUBLE_TAP_TIME = .6f;
        private float firstTapTime;

        private bool isShow = false;

        public UnitData Data { get; private set; }
        public bool IsInitialize { get; private set; }
        private Action<UnitData, int, int> OnSelect;

        public void Start()
        {
            objectSelect.SetSlick(Click);
        }

        public void SetSelectAction(Action<UnitData, int, int> onSelect) =>
            OnSelect = onSelect;

        public void LoadData(Func<int, UnitData> dataGetter)
        {
            Data = dataGetter(int.Parse(unitId));

            Availabilty availability = Data.Availability;
            bodyRenderer.Apply(availability);
            borderRenderer.Apply(availability, false);

            IsInitialize = true;
        }

        public void GoToBalcony() =>
            ballconyCamPoint.Set();

        private void Click()
        {
            if (isShow) return;

            if (firstTapTime + DOUBLE_TAP_TIME > Time.time)
                Select();
            else
                firstTapTime = Time.time;

            void Select()
            {
                OnSelect?.Invoke(Data, unitCode, int.Parse(unitId));
                isShow = true;
                borderRenderer.Apply(Data.Availability, true);
            }
        }

        public void UnSelect()
        {
            if (!isShow) return;

            isShow = false;

            borderRenderer.Apply(Data.Availability, false);
        }

        public void Highlight(bool value)
        {
            if (!IsInitialize) return;

            borderRenderer.Apply(Data.Availability, false);
            objectSelect.SetColliderAction(value);

            borderRenderer.SetActive(value);
            bodyRenderer.SetActive(value);
        }
    }
}