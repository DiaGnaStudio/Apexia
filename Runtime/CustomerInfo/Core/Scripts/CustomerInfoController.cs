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
        private readonly OrderSender senderAPI = new();

        private Action OnSignOut;
        private Action<ClientInfo> OnSignIn;

        private Func<OrderInfo[]> GetUnits;
        private Action<int> OnDeleteOrder;
        private Action OnDeleteAllOrders;

        public CustomerInfoController(Action<bool> onInputChange)
        {
            inputControoler = new(onInputChange);
        }

        #region Sign in/out

        public void SetSignAction(Action signOut, Action<ClientInfo> signIn)
        {
            OnSignOut = signOut;
            OnSignIn = signIn;
        }

        public void SignInAsGuest()
        {
            profileStorage.Add(ClientInfo.Guest);
            OnSignIn.Invoke(ClientInfo.Guest);
        }

        public void SignIn()
        {
            loaderAPI.Load(inputControoler.FirstName, inputControoler.LastName, inputControoler.PhoneNumber, inputControoler.Email, Complete);

            void Complete(ClientInfo info)
            {
                profileStorage.Add(info);
                OnSignIn.Invoke(info);
            }
        }

        public void SignOut()
        {
            profileStorage.Add(null);
        }

        public (Sprite avatar, string username) GetUser()
        {
            return (null, GetClient(false).FullName);
        }

        #endregion

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

        #region Order

        public void InitializeOrder(Func<OrderInfo[]> getOrders, Action<int> deleteOrder, Action clearAll, Action onSuccessSend, Action onFailureSend)
        {
            GetUnits = getOrders;
            OnDeleteOrder = deleteOrder;
            OnDeleteAllOrders = clearAll;
            senderAPI.Initialize(onSuccessSend, onFailureSend);
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
