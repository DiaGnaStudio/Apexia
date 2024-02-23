using System;
using UScreens;

namespace DollHouse.View
{
    public class DollHouseViewController : UScreenGeneric<DollHouseViewController, DollHouseView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.InfoPanel.Initialize();
            View.InfoPanel.Hide();
        }

        public void Show(string name, string unitType, int area)
        {
            View.InfoPanel.SetData(name, unitType, area);

            Show();
        }

        public void SetCloseAction(Action action) =>
            View.CloseButton.SetAction(action);

        public override void Show()
        {
            base.Show();
            View.InfoPanel.Show();
        }

        public override void Hide()
        {
            View.InfoPanel.Hide();
            base.Hide();
        }
    }
}