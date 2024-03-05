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

        public void Send(string firstName, string lastName, string phone, string email, Action<UnityWebRequest> responseCallback)
        {
            var reqData = sendAPI.CreateRequestData();
            reqData.AppendUrl(email);
            reqData.BodyJson = JsonConvert.SerializeObject(new
            {
                first_name = firstName,
                last_name = lastName,
                phone
            });
            Debug.Log(reqData.BodyJson);
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }
}