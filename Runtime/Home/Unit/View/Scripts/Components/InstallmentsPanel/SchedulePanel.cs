using TMPro;
using UnityEngine;

namespace Unit.View.Components.Installments
{
    internal class SchedulePanel : MonoBehaviour
    {
        private const string NUMBER_FORMAT = "{0:n0}";

        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text costText;
        [SerializeField] private TMP_Text timeText;
        [SerializeField] private TMP_Text typeText;
        [SerializeField] private TMP_Text areaText;

        public void SetData(string name, int cost, int time, string type, string area)
        {
            nameText.SetText(name);
            costText.SetText(string.Format($"OMR {NUMBER_FORMAT}", cost));
            timeText.SetText(string.Format($"{NUMBER_FORMAT} Months", time));
            typeText.SetText(type);
            areaText.SetText(string.Format($"{NUMBER_FORMAT} SQM", area));
        }
    }
}