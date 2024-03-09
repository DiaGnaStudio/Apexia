using System;
using UScreens;

namespace Login.View
{
    public class LoginViewConroller : UScreenGeneric<LoginViewConroller, LoginView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.Panel.Initialize();
        }

        public void OnChangeEmail(Action<string> onChanged) =>
            View.Panel.Email.SetChangeInput(onChanged);

        public void OnChangePassword(Action<string> onChanged) =>
            View.Panel.Password.SetChangeInput(onChanged);

        public void SetLoginAction(Action action) =>
            View.Panel.LoginBTN.SetAction(action);

        public void SetCloseAction(Action action) =>
            View.CloseBTN.onClick.AddListener(action.Invoke);

        public void SetButtonIntractable(bool value) =>
            View.Panel.LoginBTN.SetIntractable(value);

        public void ClearInput()
        {
            View.Panel.Email.Clear();
            View.Panel.Password.Clear();
        }

        public override void Show()
        {
            //base.Show();
            View.Panel.Show();
        }

        public override void Hide()
        {
            View.Panel.Hide();
            //base.Hide();
        }
    }
}