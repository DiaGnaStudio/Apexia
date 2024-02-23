using System;
using UScreens;

namespace ProjectInfo.View
{
    public class ProjectInfoViewController : UScreenGeneric<ProjectInfoViewController, ProjectInfoView>
    {
        Func<string> PresenterNameGetter;

        public override void InitializeState() { }

        public override void InitializeView() { }

        public void SetPresenterName(Func<string> name) =>
            PresenterNameGetter = name;

        public void SetCustomerName(string name) =>
            View.CustomerNameTxt.SetText(name);

        public override void Show()
        {
            base.Show();
            View.PresenterNameTxt.SetText(PresenterNameGetter());
        }
    }
}