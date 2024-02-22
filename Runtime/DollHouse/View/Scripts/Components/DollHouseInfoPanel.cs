using TMPro;
using UnityEngine;
using UScreens;

namespace DollHouse.View.Components
{
    internal class DollHouseInfoPanel : UPanel
    {
        [SerializeField] private TMP_Text unitCodeTxt;
        [SerializeField] private TMP_Text unitTypeTxt;
        [SerializeField] private TMP_Text areaTxt;

        public void SetData(string name, string unitType, int area)
        {
            unitCodeTxt.SetText(name);
            unitTypeTxt.SetText(unitType);
            areaTxt.SetText(area.ToString());
        }
    }
}