using Newtonsoft.Json;
using System;
using UnityEngine.Networking;

namespace UnitPayment.Provider
{
    public static class UnitPaymentService
    {
        private static readonly UnitPaymentProvider provider;

        static UnitPaymentService() =>
            provider = UnitPaymentProvider.Load;

        public static void GetById(string id, Action<UnitPaymentData> onLoadProfile, Action<string> onError)
        {
            provider.GetById(id, Callback);

            void Callback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var data = JsonConvert.DeserializeObject<UnitPaymentData>(callbackReq.downloadHandler.text);

                onLoadProfile.Invoke(data);
            }
        }
    }
}