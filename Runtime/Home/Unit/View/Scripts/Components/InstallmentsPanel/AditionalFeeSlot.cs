using TMPro;
using UnityEngine;

namespace Unit.View.Components.Installments
{
    internal class AditionalFeeSlot : MonoBehaviour
    {
        private const string NUMBER_FORMAT = "{0:n0}";
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text FeeText;

        public void SetData(string title, int fee)
        {
            titleText.SetText(title);
            FeeText.SetText(string.Format($"OMR {NUMBER_FORMAT}", fee));
        }
    }
}