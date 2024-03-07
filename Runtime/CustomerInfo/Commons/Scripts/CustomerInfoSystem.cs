using CustomerInfo.Core;
using CustomerInfo.Data;
using CustomerInfo.View;
using System;
using UnityEngine;
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
            logic = new(view.SetLoginIntractable);

            view.SetChangeInfo(logic.CheckFirstName, logic.CheckLastName, logic.CheckPhone, logic.CheckEmail);
            view.Initialize(logic.SignOut, logic.GetUser, logic.Share, logic.ClearAll, logic.DeleteOrder, logic.GetAllOrders, logic.SignIn, logic.SignInAsGuest);
        }

        public static void Initialzie(Action signOut, Func<OrderInfo[]> getOrders, Action<int> deleteBookmark, Action clearAll, Action<ClientInfo> onLoginCustomer)
        {
            logic.SetSignAction(signOut, SignIn);
            logic.InitializeOrder(getOrders, deleteBookmark, clearAll, ShareSuccessfully, ShareFailure);

            void SignIn(ClientInfo customer)
            {
                onLoginCustomer.Invoke(customer);
                view.ShowProfile();
            }

            void ShareSuccessfully()
            {
                Debug.Log("ShareSuccessfully");
            }

            void ShareFailure()
            {
                Debug.Log("ShareFailure");
            }
        }

        public static void Show()
        {
            if (logic.GetClient(true) != null)
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

        public static ClientInfo GetClientInfo(bool canBeNull = true) =>
            logic.GetClient(canBeNull);
    }
}
