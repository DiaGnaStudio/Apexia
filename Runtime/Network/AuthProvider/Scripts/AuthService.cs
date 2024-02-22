using Auth.Provider.Data;
using Newtonsoft.Json;
using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Auth.Provider
{
    public static class AuthService
    {
        private static readonly AuthProvider provider;

        static AuthService() =>
            provider = AuthProvider.Load;

        public static void Login(string email, string password, bool remember, Action<UserData> onLoadProfile, Action<string> onError)
        {
            provider.Login(email, password, remember, LoginCallback);

            void LoginCallback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var data = JsonConvert.DeserializeObject<AuthData>(callbackReq.downloadHandler.text);

                JWTTokenResolver.SetAccessToken(data.data.token) ;

                Debug.Log(data.ToString());

                onLoadProfile.Invoke(data.data.user);
            }
        }
    }
}