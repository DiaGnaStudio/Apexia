using CustomerInfo.Data;
using System;
using UnityEngine;

namespace CustomerInfo.Core
{
    public class CustomerInfoController
    {
        public bool HasSignIn { get; private set; }

        private Action OnSignOut;

        public void SetSignOutAction(Action signOut)
        {
            OnSignOut = signOut;
        }

        public void SignInAsGuest()
        {
            HasSignIn = true;
        }

        public void SignIn()
        {
            HasSignIn = true;
        }

        public void SignOut()
        {
            HasSignIn = false;
            OnSignOut.Invoke();
        }

        public (Sprite avatar, string username) GetUser() =>
            (null, "NEW USER");

        public void Share()
        {

        }

        public void ClearAll()
        {

        }

        public void DeleteBookmark(UnifInfo info)
        {

        }

        public UnifInfo[] GetAll() =>
            new UnifInfo[0];
    }
}
