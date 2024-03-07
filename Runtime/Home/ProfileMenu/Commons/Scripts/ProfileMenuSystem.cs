using ProfileMenu.Core;
using ProfileMenu.View;
using System;
using UnityEngine;
using UScreens;

namespace ProfileMenu
{
    public static class ProfileMenuSystem
    {
        private static readonly ProfileMenuController logic;
        private static readonly ProfileMenuViewController view;

        static ProfileMenuSystem()
        {
            view = UScreenRepo.Get<ProfileMenuViewController>();
            logic = new(view.SetData);
        }

        public static void Load() =>
            logic.Load();

        public static void Initialize(Action profileAction, Action settingAction, Action signOutAction)
        {
            view.SetProfileAction(profileAction);
            view.SetSettingAction(settingAction);
            view.SetSignOutAction(SignOut);

            void SignOut()
            {
                signOutAction.Invoke();
                logic.SignOut();
            }
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