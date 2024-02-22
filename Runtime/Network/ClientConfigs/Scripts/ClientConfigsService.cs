using System;
using UnityEngine.Networking;

namespace ClientConfigs.Provider
{
    public static class ClientConfigsService
    {
        private static readonly ClientConfigsProvider provider;

        static ClientConfigsService() =>
            provider = ClientConfigsProvider.Load;

        public static void Send(string firstName, string lastName, ulong phone, Action OnLoad, Action<string> onError)
        {
            provider.Send(firstName, lastName, phone, LoginCallback);

            void LoginCallback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                OnLoad.Invoke();
            }
        }
    }
}