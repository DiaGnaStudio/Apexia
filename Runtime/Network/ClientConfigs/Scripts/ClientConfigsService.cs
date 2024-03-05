using ClientConfigs.Provider.Data;
using Newtonsoft.Json;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace ClientConfigs.Provider
{
    public static class ClientConfigsService
    {
        private static readonly ClientConfigsProvider provider;

        static ClientConfigsService() =>
            provider = ClientConfigsProvider.Load;

        public static void Send(string firstName, string lastName, string phone, string email, Action<Client> OnLoad, Action<string> onError)
        {
            provider.Send(firstName, lastName, phone, email, LoginCallback);

            void LoginCallback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var data = JsonConvert.DeserializeObject<ClientResponse>(callbackReq.downloadHandler.text);
                Debug.Log(data.client.ToString());

                OnLoad.Invoke(data.client);
            }
        }
    }
}