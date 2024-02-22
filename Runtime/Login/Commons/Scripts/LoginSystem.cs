using Login.Core;
using Login.View;
using System;
using UScreens;

namespace Login
{
    public static class LoginSystem
    {
        private static readonly LoginController logic;
        private static readonly LoginViewConroller view;

        static LoginSystem()
        {
            view = UScreenRepo.Get<LoginViewConroller>();
            logic = new LoginController(OnAccept, OnChanged);

            view.OnChangeEmail(logic.EmailChanged);
            view.OnChangePassword(logic.PasswordChanged);
            view.SetLoginAction(logic.CheckInput);

            void OnAccept()
            {
                view.Hide();
            }

            void OnChanged(bool value)
            {
                view.SetButtonIntractable(value);
            }
        }

        public static void Initialize(Action<string> onLoadPresenter, Action onLogin, Action onSignOut) =>
            logic.SetLoginAction(onLoadPresenter, onLogin, onSignOut);

        public static void Show() =>
            view.Show();

        public static void Hide() =>
            view.Hide();

        public static void SignOut() => 
            logic.SignOut(view.ClearInput);

        public static string GetPresenter() =>
            logic.GetPresenter();
    }
}