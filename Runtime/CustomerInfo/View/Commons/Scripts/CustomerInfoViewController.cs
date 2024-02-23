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

            View.SignInPanel.SetGlobalLoginAction(View.ProfilePanel.Show);
        }

        public void Initialize(Action signOut,
                               Func<(Sprite avatar, string username)> getter,
                               Action share,
                               Action clearAll,
                               Action<UnifInfo> deleteBookmark,
                               Func<UnifInfo[]> infoGetter,
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

        public void OnChangeName(Action<string> onChanged) =>
            View.SignInPanel.OnChangeName(onChanged);

        public void OnChangeEmail(Action<string> onChanged) =>
            View.SignInPanel.OnChangeEmail(onChanged);

        public void ShowProfile() =>
            View.ProfilePanel.Show();

        public void ShowSignUp() =>
            View.SignInPanel.Show();

        public override void Hide()
        {
            View.ProfilePanel.Hide();
            View.SignInPanel.Hide();
        }
    }
}
