using About.Assets;
using System;
using UScreens;

namespace About.View
{
    public class AboutViewController : UScreenGeneric<AboutViewController, AboutView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.SectionPanel.SetClickAction(View.SlideshowPanel.Initialize);

            View.ControllerPanel.SetButton(View.SlideshowPanel.NextImage, View.SlideshowPanel.PreviousImage);
            View.ControllerPanel.SetStopAction(View.SlideshowPanel.PauseSlideShow, View.SlideshowPanel.ResumeSlideShow);
        }

        public void SetCards(AboutAsset[] assets) =>
            View.SectionPanel.SetCards(assets);

        public void SetCustomerInfoAction(Action action) =>
            View.CustomerInfoButton.SetAction(action);

        public void SetProjectAction(Action action) =>
            View.ProjectButton.SetAction(action);

        public void SetSignOutAction(Action action) =>
            View.SignOutButton.SetAction(action);

        public void SetCloseAction(Action action) =>
            View.CloseButton.SetAction(action);

        public override void Show() => 
            View.Show();

        public override void Hide() => 
            View.Hide();
    }
}