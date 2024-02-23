using SidePanel.View.SharedTypes;
using System;
using UnityEngine;
using UScreens;

namespace SidePanel.View
{
    public class SidePanelViewContoller : UScreenGeneric<SidePanelViewContoller, SidePanelView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            Hide();
        }

        public void SetOpenPages(Action<Transform> explorePanel,
                                 Action<Transform> surroundingPanel,
                                 Action<Transform> amenitiePanel,
                                 Action<Transform> unitPanel,
                                 Action<Transform> galleryPanel)
        {
            View.PagesPanel.SetOpenActions(new PageParentActions(explorePanel,
                                                                 surroundingPanel,
                                                                 amenitiePanel,
                                                                 unitPanel,
                                                                 galleryPanel));
        }

        public void SetProfileAction(Action<Transform> open, Action close) =>
            View.ProfileBtn.SetActions(open, close);

        public void SetCustomerAction(Action onSwitch) =>
            View.CustomerBtn.SetActions(onSwitch);

        public void SetClosePages(params Action[] actions)
        {
            View.PagesPanel.SetGlobalAction(OnClick);

            void OnClick()
            {
                View.Animation.ForceHide();
                foreach (var action in actions)
                    action.Invoke();
            }
        }

        public void Initialize(Action<float> onChangeDay, Action exit, Action openHome)
        {
            View.DaySlider.Initialize(onChangeDay);
            View.HomeBtn.onClick.AddListener(openHome.Invoke);
            View.ExitBtn.onClick.AddListener(exit.Invoke);
        }

        public override void Show()
        {
            base.Show();
            View.PagesPanel.ShowDefault();
        }
    }
}