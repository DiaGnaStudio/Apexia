using System;
using UnityEngine;
using UScreens;

namespace ProfileMenu.View
{
    public class ProfileMenuViewController : UScreenGeneric<ProfileMenuViewController, ProfileMenuView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.StaticPanel.Initialize();
            View.StaticPanel.Hide();

            View.InfoPanel.Initialize();
        }

        public void SetData(Sprite avatar, string name) =>
            View.InfoPanel.SetData(avatar, name);

        public void SetProfileAction(Action action) =>
            View.InfoPanel.SetProfileAction(action);

        public void SetSettingAction(Action action) =>
            View.InfoPanel.SetSettingAction(action);

        public void SetSignOutAction(Action action) =>
            View.InfoPanel.SetSignOutAction(action);

        public void SetParent(Transform parent) =>
            View.StaticPanel.transform.SetParent(parent, false);

        public override void Show()
        {
            base.Show();
            View.StaticPanel.Show();
        }

        public override void Hide()
        {
            View.StaticPanel.Hide();
            base.Hide();
        }
    }
}