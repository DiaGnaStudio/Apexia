using Newtonsoft.Json;
using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Order.Provider
{
    [CreateAssetMenu(fileName = "OrderProvider", menuName = "Providers/Order")]
    internal class OrderProvider : Provider<OrderProvider>
    {
        [SerializeField] private HTTPRequestCard sendAPI;

        public void Send(int[] unitIds, int clientId, Action<UnityWebRequest> responseCallback)
        {
            var reqData = sendAPI.CreateRequestData();
            reqData.BodyJson = JsonConvert.SerializeObject(new
            {
                units_id = $"[{string.Join(", ", unitIds)}]",
                client_id = clientId
            });
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }
}