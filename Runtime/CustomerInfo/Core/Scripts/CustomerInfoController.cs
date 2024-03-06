using CustomerInfo.Core.Module;
using CustomerInfo.Data;
using System;
using System.Linq;
using UnityEngine;

namespace CustomerInfo.Core
{
    public class CustomerInfoController
    {
        private readonly InputControoler inputControoler;
        private readonly ProfileStorage profileStorage = new();

        private readonly ClientLoader loaderAPI = new();
        private readonly OrderSender senderAPI = new(null, null);

        private Action OnSignOut;
        private readonly Action OnSignIn;

        private Func<OrderInfo[]> GetUnits;
        private Action<int> OnDeleteOrder;
        private Action OnDeleteAllOrders;

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
            return (null, GetClient(false).FullName);
        }

        #region Order

        public void InitializeOrder(Func<OrderInfo[]> getOrders, Action<int> deleteOrder, Action clearAll)
        {
            GetUnits = getOrders;
            OnDeleteOrder = deleteOrder;
            OnDeleteAllOrders = clearAll;
        }

        public void ClearAll() =>
            OnDeleteAllOrders.Invoke();

        public void DeleteOrder(OrderInfo info) =>
            OnDeleteOrder.Invoke(info.Id);

        public OrderInfo[] GetAllOrders() =>
            GetUnits();

        public ClientInfo GetClient(bool canBeNull = true) =>
            canBeNull ? profileStorage.Get() : profileStorage.Get() ?? ClientInfo.Guest;

        public void Share() =>
            senderAPI.Send(GetUnits().Select(unit => unit.Id).ToArray(), GetClient(false).Id);

        #endregion
    }
}
