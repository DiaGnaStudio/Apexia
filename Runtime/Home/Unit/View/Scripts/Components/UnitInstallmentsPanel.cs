using Unit.Data;
using Unit.View.Components.Installments;
using UnityEngine;
using UScreens;

namespace Unit.View.Components
{
    internal class UnitInstallmentsPanel : UPanel
    {
        [SerializeField] private SchedulePanel infoPanel;
        [SerializeField] private PaymentPanel paymentPanel;
        [SerializeField] private AditionalFeePanel aditionalFeePanel;

        public void Show(UnitInstallmentsData data)
        {
            infoPanel.SetData(data.UnitInfo.Name, data.UnitInfo.Price, data.UnitInfo.Duration, data.UnitInfo.Type, data.UnitInfo.Area);
            paymentPanel.SetData(data.Payments);

            if (data.AditionalFees.Length > 0)
                aditionalFeePanel.SetData(data.AditionalFees);
            else
                aditionalFeePanel.SetDiactive();

            base.Show();
        }
    }
}