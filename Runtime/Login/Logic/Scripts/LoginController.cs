using System;

namespace Login.Core
{
    public class LoginController
    {
        private readonly VerifyEmail verifyEmail = new();
        private readonly VerifyPassword verifyPassword = new();

        private readonly LoginAPI api = new();

        private readonly Action OnAccept;
        private readonly Action<bool> OnChanged;

        private string presenterName;

        private Action<string> OnLoadPresenter;
        private Action OnLogin;
        private Action OnSignOut;

        public LoginController(Action onAccept, Action<bool> onChanged)
        {
            OnAccept = onAccept;
            OnChanged = onChanged;

            onChanged.Invoke(false);
        }

        public void SetLoginAction(Action<string> onLoadInfo, Action onLogin,Action onSignOut)
        {
            OnLoadPresenter = onLoadInfo;
            OnLogin = onLogin;
            OnSignOut = onSignOut;
        }

        public void CheckInput()
        {
            if (IsVerify())
            {
                api.Login(verifyEmail.Email, verifyPassword.Password, false, Accept);

                void Accept(string presenterName)
                {
                    OnAccept.Invoke();
                    OnLoadPresenter.Invoke(presenterName);

                    OnLogin.Invoke();

                    this.presenterName = presenterName;
                }
            }
        }

        public void EmailChanged(string email)
        {
            verifyEmail.IsEmail(email);

            OnChanged.Invoke(IsVerify());
        }

        public void PasswordChanged(string password)
        {
            verifyPassword.IsPassword(password);

            OnChanged.Invoke(IsVerify());
        }

        private bool IsVerify() =>
            verifyEmail.IsCorrect && verifyPassword.IsCorrect;

        public void SignOut(Action clearInput)
        {
            OnSignOut.Invoke();
            clearInput.Invoke();
        }

        public string GetPresenter() =>
            presenterName;
    }
}