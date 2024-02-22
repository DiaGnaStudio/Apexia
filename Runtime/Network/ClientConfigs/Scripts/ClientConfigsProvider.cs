using Newtonsoft.Json;
using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace ClientConfigs.Provider
{
    [CreateAssetMenu(fileName = "ClientConfigsProvider", menuName = "Providers/ClientConfigs")]
    public class ClientConfigsProvider : Provider<ClientConfigsProvider>
    {
        [SerializeField] private HTTPRequestCard sendAPI;

        public void Send(string firstName, string lastName, ulong phone, Action<UnityWebRequest> responseCallback)
        {
            var reqData = sendAPI.CreateRequestData();
            reqData.BodyJson = JsonConvert.SerializeObject(new
            {
                first_name = firstName,
                last_name = lastName,
                phone
            });
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }
}