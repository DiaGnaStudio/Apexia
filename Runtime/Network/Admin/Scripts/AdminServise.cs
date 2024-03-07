using Admin.Provider.Data;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;

namespace Admin.Provider
{
    public static class AdminServise
    {
        private static readonly AdminProvider provider;

        static AdminServise() =>
            provider = AdminProvider.Load;

        public static void Get(Action<User> onLoadProfile, Action<string> onError)
        {
            provider.Get(Callback);

            void Callback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var data = JsonConvert.DeserializeObject<User>(callbackReq.downloadHandler.text);

                onLoadProfile.Invoke(data);
            }
        }
    }
}