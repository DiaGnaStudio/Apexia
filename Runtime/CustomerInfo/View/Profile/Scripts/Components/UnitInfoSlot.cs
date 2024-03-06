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

        private OrderInfo _info;

        private static Action<OrderInfo> OnDelete;

        public void SetData(OrderInfo info)
        {
            _info = info;

            unitNameText.SetText(info.UnitName);
            unitTypeText.SetText(info.UnitType);
            floorText.SetText(ToOrdinal(info.Floor));
            
            priceText.gameObject.SetActive(true);
            if (int.TryParse(info.Price, out int price))
                priceText.SetText(string.Format("{0} OMR", price.ToString("N0")));
            else if (info.Price == string.Empty)
                priceText.gameObject.SetActive(false);
            else
                priceText.SetText(info.Price);

            areaText.SetText(string.Format("{0} sqft", info.Area));

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
            gameObject.SetActive(false);
        }

        public static void SetDeleteAction(Action<OrderInfo> action) =>
            OnDelete = action;
    }

}
