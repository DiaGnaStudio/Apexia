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
            View.InfoPanel.Initialize();
            View.InfoPanel.Hide();
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
            View.InfoPanel.transform.SetParent(parent, false);

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