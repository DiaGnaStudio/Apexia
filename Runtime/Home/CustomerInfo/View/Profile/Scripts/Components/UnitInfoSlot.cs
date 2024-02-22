using CustomerInfo.Data;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CustomerInfo.View.Profile.Components
{
    internal class UnitInfoSlot : MonoBehaviour
    {
        [SerializeField] private Information unitNameText;
        [SerializeField] private Information unitTypeText;
        [SerializeField] private Information floorText;
        [SerializeField] private Information priceText;
        [SerializeField] private Information areaText;

        [SerializeField] private Button deleteButton;

        private UnifInfo _info;

        private static Action<UnifInfo> OnDelete;

        public void SetData(UnifInfo info)
        {
            _info = info;

            unitNameText.SetText(info.UnitName);
            unitTypeText.SetText(info.UnitType);
            floorText.SetText(ToOrdinal(info.Floor));
            priceText.SetText(string.Format("{0} OMR", info.Price.ToString("N0")));
            priceText.SetText(string.Format("{0} sqft", info.Area));

            string ToOrdinal(int number)
            {
                if (number <= 0)
                    return number.ToString();

                return (number % 100) switch
                {
                    11 or 12 or 13 => number + "th",
                    _ => (number % 10) switch
                    {
                        1 => number + "st",
                        2 => number + "nd",
                        3 => number + "rd",
                        _ => number + "th",
                    },
                };
            }
        }

        private void OnEnable() =>
            deleteButton.onClick.AddListener(Delete);

        private void OnDisable() =>
            deleteButton.onClick.AddListener(Delete);

        private void Delete()
        {
            OnDelete.Invoke(_info);
            DestroyImmediate(gameObject);
        }

        public static void SetDeleteAction(Action<UnifInfo> action) =>
            OnDelete = action;
    }

}
