using Unit.Data;
using UnityEngine;
using UPatterns;

namespace Unit.View.Components.Installments
{
    internal class AditionalFeePanel : MonoBehaviour
    {
        [SerializeField] private Pool<AditionalFeeSlot> slotPool;

        public void SetData(UnitInstallmentsData.AditionalFee[] fees)
        {
            gameObject.SetActive(true);

            slotPool.DeactiveAllInstance();

            foreach (var data in fees)
                slotPool.Get.SetData(data.Title, data.Fee);
        }

        public void SetDiactive() =>
            gameObject.SetActive(false);
    }
}