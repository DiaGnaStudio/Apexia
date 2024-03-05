using CustomerInfo.Core.Module;
using CustomerInfo.Data;
using System;
using UnityEngine;

namespace CustomerInfo.Core
{
    public class CustomerInfoController
    {
        private readonly InputControoler inputControoler;
        private readonly ProfileStorage profileStorage = new();

        private readonly ClientLoader loaderAPI = new();

        public bool HasSignIn => profileStorage.Get() != null;

        private Action OnSignOut;
        private readonly Action OnSignIn;

        public CustomerInfoController(Action<bool> onInputChange, Action onSignIn)
        {
            inputControoler = new(onInputChange);
            OnSignIn = onSignIn;
        }

        public void SetSignOutAction(Action signOut)
        {
            OnSignOut = signOut;
        }

        public void SignInAsGuest()
        {
            profileStorage.Add(ClientInfo.Guest);
            OnSignIn.Invoke();
        }

        public void SignIn()
        {
            loaderAPI.Load(inputControoler.FirstName, inputControoler.LastName, inputControoler.PhoneNumber, inputControoler.Email, Complete);

            void Complete(ClientInfo info)
            {
                profileStorage.Add(info);
                OnSignIn.Invoke();
            }
        }

        public void SignOut()
        {
            profileStorage.Add(null);
            OnSignOut.Invoke();
        }

        #region Input Controlling

        public void CheckFirstName(string value) =>
            inputControoler.ChangeFirstName(value);

        public void CheckLastName(string value) =>
            inputControoler.ChangeLastName(value);

        public void CheckPhone(string value) =>
            inputControoler.ChangePhoneNumber(value);

        public void CheckEmail(string value) =>
            inputControoler.ChangeEmail(value);


        #endregion

        public (Sprite avatar, string username) GetUser()
        {
            var client = profileStorage.Get();
            var username = string.Format("{0} {1}", client.FirstName, client.LastName);
            return (null, username);
        }

        public void Share()
        {
            // call api
        }

        public void ClearAll()
        {

        }

        public void DeleteOrder(OrderInfo info)
        {

        }

        public OrderInfo[] GetAllOrders() =>
            new OrderInfo[0];
    }
}
