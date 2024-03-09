using System;
using TMPro;
using UnityEngine;
using UScreens;

namespace Unit.View
{

    internal class UnitBalconyPanel : UPanel
    {
        [SerializeField] private TMP_Text coedText;
        [SerializeField] private TMP_Text floorText;

        internal void Initialize(Action showBalcony, Action hideBalcony)
        {
            OnHide += hideBalcony;
            OnShow += showBalcony;
        }

        public void SetData(int code, int floor)
        {
            coedText.SetText(code.ToString());
            floorText.SetText(floor.ToString());
        }
    }
}