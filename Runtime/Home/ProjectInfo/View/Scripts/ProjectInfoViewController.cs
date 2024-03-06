using System;
using UScreens;

namespace ProjectInfo.View
{
    public class ProjectInfoViewController : UScreenGeneric<ProjectInfoViewController, ProjectInfoView>
    {
        private Func<string> PresenterNameGetter;
        private Func<string> CustomerNameGetter;

        public override void InitializeState() { }

        public override void InitializeView() { }

        public void SetPresenterName(Func<string> nameGetter) =>
            PresenterNameGetter = nameGetter;

        public void SetCustomerName(Func<string> nameGetter) =>
            CustomerNameGetter = nameGetter;

        public override void Show()
        {
            base.Show();
            View.PresenterNameTxt.SetText(PresenterNameGetter());
            View.CustomerNameTxt.SetText(CustomerNameGetter());
        }
    }
}