using CustomerInfo.Core;
using CustomerInfo.View;
using System;
using UScreens;

namespace CustomerInfo
{
    public static class CustomerInfoSystem
    {
        private static readonly CustomerInfoController logic;
        private static readonly CustomerInfoViewController view;

        static CustomerInfoSystem()
        {
            logic = new();
            view = UScreenRepo.Get<CustomerInfoViewController>();

            view.SetLoginIntractable(true);

            view.Initialize(logic.SignOut, logic.GetUser, logic.Share, logic.ClearAll, logic.DeleteBookmark, logic.GetAll, logic.SignIn, logic.SignInAsGuest);
        }

        public static void Initialzie(Action signOut)
        {
            logic.SetSignOutAction(signOut);
        }

        public static void Show()
        {
            if (logic.HasSignIn)
                view.ShowProfile();
            else
                view.ShowSignUp();
        }

        public static void Hide() =>
            view.Hide();

        public static void Switch()
        {
            if (view.IsShowing)
                Hide();
            else
                Show();
        }
    }
}
