using System;
using UnityEngine.Networking;

namespace Order.Provider
{
    public static class OrderService
    {
        private static readonly OrderProvider provider;

        static OrderService() =>
            provider = OrderProvider.Load;

        public static void Send(int unitId, int clientId, Action OnSuccess, Action<string> onError)
        {
            provider.Send(unitId, clientId, LoginCallback);

            void LoginCallback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                OnSuccess.Invoke();
            }
        }
    }
}