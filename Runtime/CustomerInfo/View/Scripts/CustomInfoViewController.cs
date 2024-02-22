using UScreens;

namespace CustomInfo.View
{
    public class CustomInfoViewController : UScreenGeneric<CustomInfoViewController, CustomerInfoView>
    {
        public override void InitializeState() { }

        public override void InitializeView() { }

        public void SetPresenterName(string name) =>
            View.PresenterNameTxt.SetText(name);

        public void SetCustomerName(string name) =>
            View.CustomerNameTxt.SetText(name);
    }
}