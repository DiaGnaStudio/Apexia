using System;
using UScreens;

namespace Login.View
{
    public class LoginViewConroller : UScreenGeneric<LoginViewConroller, LoginView>
    {
        public override void InitializeState() { }

        public override void InitializeView() { }

        public void OnChangeEmail(Action<string> onChanged) =>
            View.Email.SetChangeInput(onChanged);

        public void OnChangePassword(Action<string> onChanged) =>
            View.Password.SetChangeInput(onChanged);

        public void SetLoginAction(Action action) =>
            View.LoginBTN.SetAction(action);

        public void SetButtonIntractable(bool value) =>
            View.LoginBTN.SetIntractable(value);

        public void ClearInput()
        {
            View.Email.Clear();
            View.Password.Clear();
        }
    }
}