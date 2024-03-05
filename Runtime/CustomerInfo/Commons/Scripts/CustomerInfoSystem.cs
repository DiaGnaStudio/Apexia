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
            view = UScreenRepo.Get<CustomerInfoViewController>();
            logic = new(view.SetLoginIntractable, view.ShowProfile);

            view.SetChangeInfo(logic.CheckFirstName, logic.CheckLastName, logic.CheckPhone, logic.CheckEmail);
            view.Initialize(logic.SignOut, logic.GetUser, logic.Share, logic.ClearAll, logic.DeleteOrder, logic.GetAllOrders, logic.SignIn, logic.SignInAsGuest);
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
