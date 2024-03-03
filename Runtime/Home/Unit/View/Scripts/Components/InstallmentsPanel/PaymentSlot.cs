using TMPro;
using UnityEngine;

namespace Unit.View.Components.Installments
{
    internal class PaymentSlot : MonoBehaviour
    {
        private const string NUMBER_FORMAT = "{0:n0}";
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text FeeText;
        [SerializeField] private TMP_Text dateText;

        public void SetData(string title, int fee, string date)
        {
            titleText.SetText(title);
            FeeText.SetText(string.Format($"OMR {NUMBER_FORMAT}", fee));
            dateText.SetText(date);
        }
    }
}