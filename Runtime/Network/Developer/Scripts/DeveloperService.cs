using Developer.Provider.Data;
using Newtonsoft.Json;
using System;
using UnityEngine.Networking;

namespace Developer.Provider
{
    public static class DeveloperService
    {
        private static readonly DeveloperProvider provider;

        static DeveloperService() =>
            provider = DeveloperProvider.Load;

        public static void GetAll(Action<DeveloperData[]> onLoadProfile, Action<string> onError)
        {
            provider.Get(Callback);

            void Callback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var respone = JsonConvert.DeserializeObject<RootObject>(callbackReq.downloadHandler.text);

                onLoadProfile.Invoke(respone.developers);
            }
        }

        private class RootObject
        {
            public int status;
            public DeveloperData[] developers;
        }
    }
}