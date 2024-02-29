using Unit.Data;
using UnityEngine;
using UPatterns;

namespace Unit.View.Components.Installments
{
    internal class PaymentPanel : MonoBehaviour
    {
        [SerializeField] private Pool<PaymentSlot> slotPool;

        public void SetData(UnitInstallmentsData.Payment[] payments)
        {
            slotPool.DeactiveAllInstance();

            foreach (var data in payments)
                slotPool.Get.SetData(data.Title, data.Fee, data.DateInLetter);
        }
    }
}