using CustomerInfo.Data;
using System;
using UnityEngine;
using UScreens;

namespace CustomerInfo.View
{
    public class CustomerInfoViewController : UScreenGeneric<CustomerInfoViewController, CustomerInfoView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.ProfilePanel.Initialize();
            View.ProfilePanel.Hide();
            View.ProfilePanel.SetCloseAction(Hide);

            View.SignInPanel.Initialize();
            View.SignInPanel.Hide();
            View.SignInPanel.SetCloseAction(Hide);

            //View.SignInPanel.SetGlobalLoginAction(View.ProfilePanel.Show);
        }

        public void Initialize(Action signOut,
                               Func<(Sprite avatar, string username)> getter,
                               Action share,
                               Action clearAll,
                               Action<OrderInfo> deleteBookmark,
                               Func<OrderInfo[]> infoGetter,
                               Action userlogin,
                               Action guestLogin)
        {
            View.ProfilePanel.SetActions(SignOut, share, clearAll, deleteBookmark);
            View.ProfilePanel.SetCustomerData(getter);
            View.ProfilePanel.SetBookmarksGetter(infoGetter);

            View.SignInPanel.SetLoginAction(userlogin);
            View.SignInPanel.SetGuestAction(guestLogin);

            void SignOut()
            {
                signOut.Invoke();
                View.SignInPanel.Hide();
                View.ProfilePanel.Hide();
            }
        }

        public void SetLoginIntractable(bool value) =>
            View.SignInPanel.SetButtonIntractable(value);

        public void SetChangeInfo(Action<string> onfirstNameChanged, Action<string> onlastNameChanged, Action<string> onPhoneChanged, Action<string> onEmailChanged)
        {
            View.SignInPanel.OnChangeName(onfirstNameChanged, onlastNameChanged);
            View.SignInPanel.OnChangePhone(onPhoneChanged);
            View.SignInPanel.OnChangeEmail(onEmailChanged);
        }

        public void ShowProfile()
        {
            View.SignInPanel.Hide();
            View.ProfilePanel.Show();
        }

        public void ShowSignUp()
        {
            View.ProfilePanel.Hide();
            View.SignInPanel.ClearInput();
            View.SignInPanel.Show();
        }

        public override void Hide()
        {
            View.ProfilePanel.Hide();
            View.SignInPanel.Hide();
        }
    }
}
