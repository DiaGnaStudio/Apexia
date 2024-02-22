using UScreens;

namespace Exit.View
{
    public class ExitViewController : UScreenGeneric<ExitViewController, ExitView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.Popup.Initialize();
            View.Popup.Hide();
        }

        public override void Show()
        {
            base.Show();
            View.Popup.Show();
        }

        public override void Hide()
        {
            View.Popup.Hide();
            base.Hide();
        }
    }
}