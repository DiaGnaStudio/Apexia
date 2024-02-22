using ProfileMenu.View;
using System;
using UnityEngine;
using UScreens;

namespace ProfileMenu
{
    public static class ProfileMenuSystem
    {
        private static readonly ProfileMenuViewController view;

        static ProfileMenuSystem()
        {
            view = UScreenRepo.Get<ProfileMenuViewController>();
        }

        public static void SetData(Sprite avatar, string name) =>
            view.SetData(avatar, name);

        public static void Initialize(Action profileAction, Action settingAction, Action signOutAction)
        {
            view.SetProfileAction(profileAction);
            view.SetSettingAction(settingAction);
            view.SetSignOutAction(signOutAction);
        }

        public static void Show(Transform parent = null)
        {
            if (parent != null)
                view.SetParent(parent);
            view.Show();
        }

        public static void Hide() =>
            view.Hide();
    }
}