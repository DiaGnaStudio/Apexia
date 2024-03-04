using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace UnitPayment.Provider
{
    [CreateAssetMenu(fileName = "UnitPaymentProvider", menuName = "Providers/UnitPaymentProvider")]
    public class UnitPaymentProvider : Provider<UnitPaymentProvider>
    {
        [SerializeField] private HTTPRequestCard GetByIdAPI;

        public void GetById(int id, Action<UnityWebRequest> responseCallback)
        {
            var reqData = GetByIdAPI.CreateRequestData();
            reqData.AppendUrl(id + "/payment-plan/records");
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }
}