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
        private UnitBorderRenderer borderRenderer;
        private UnitBodyRenderer bodyRenderer;
        private ObjectSelect objectSelect;

        private const float DOUBLE_TAP_TIME = .6f;
        private float firstTapTime;

        private bool isShow = false;

        public UnitData Data { get; private set; }
        public bool IsInitialize { get; private set; }
        private Action<UnitData, int, string> OnSelect;

        public void Awake()
        {
            borderRenderer = GetComponentInChildren<UnitBorderRenderer>();
            bodyRenderer = GetComponentInChildren<UnitBodyRenderer>();
            objectSelect = GetComponentInChildren<ObjectSelect>();

            objectSelect.SetSlick(Click);
        }

        public void SetSelectAction(Action<UnitData, int, string> onSelect) => 
            OnSelect = onSelect;

        public void LoadData(Func<string, UnitData> dataGetter)
        {
            Data = dataGetter(unitId);

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
                OnSelect?.Invoke(Data, unitCode, unitId);
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