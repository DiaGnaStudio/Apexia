using System;
using UWarning.Data;
using UScreens;

namespace UWarning.View
{
    public class WarningViewController : UScreenGeneric<WarningViewController, WarningView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.Panel.Initialize();
            View.Panel.Hide();
        }

        public void Show(WarningCard card, Action acceptAction, Action rejectAction, string description = null)
        {
            base.Show();
            View.Panel.SetData(card, acceptAction, rejectAction, description);
            View.Panel.Show();
        }

        public override void Show()
        {
            throw new NotImplementedException("The warning card is empty");
        }

        public override void Hide()
        {
            View.Panel.Hide();
        }
    }
}
