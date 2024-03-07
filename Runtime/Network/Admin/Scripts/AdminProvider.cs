using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Admin.Provider
{
    [CreateAssetMenu(fileName = "AdminProvider", menuName = "Providers/AdminProvider")]
    internal class AdminProvider : Provider<AdminProvider>
    {
        [SerializeField] private HTTPRequestCard getAPI;
        public void Get(Action<UnityWebRequest> responseCallback)
        {
            var reqData = getAPI.CreateRequestData();
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }
}