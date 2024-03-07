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

        public void Send(int unitId, int clientId, Action<UnityWebRequest> responseCallback)
        {
            var reqData = sendAPI.CreateRequestData();
#if UNITY_EDITOR
            reqData.BodyJson = JsonConvert.SerializeObject(new
            {
                selected_unit = unitId,
                client = clientId,
                status = "Bookmarked",
                expiry_date = DateTime.UtcNow.Date,
                send_email = false
            });
#else
            reqData.BodyJson = JsonConvert.SerializeObject(new
            {
                selected_unit = unitId,
                client = clientId,
                status = "Bookmarked",
                expiry_date = DateTime.UtcNow.Date,
                send_email = true
            });
#endif

            Debug.Log(reqData.BodyJson);
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }
}