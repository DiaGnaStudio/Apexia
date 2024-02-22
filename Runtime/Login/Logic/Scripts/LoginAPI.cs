using Auth.Provider;
using Auth.Provider.Data;
using System;
using UWarning;

namespace Login.Core
{
    public class LoginAPI
    {
        private const string WARNING_ID = "LoginFaild";

        public void Login(string email, string password, bool remember, Action<string> onLoadPresenter)
        {
            AuthService.Login(email, password, remember, Load, Faild);

            void Load(UserData data)
            {
                var presenterName = string.Format("{0} {1}", data.firstname, data.lastname);
                onLoadPresenter.Invoke(presenterName);
            }

            void Faild(string error)
            {
                WarningSystem.Show(WARNING_ID, null, null);
            }
        }
    }
}