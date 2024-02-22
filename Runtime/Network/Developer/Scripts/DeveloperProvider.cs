using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Developer.Provider
{
    [CreateAssetMenu(fileName = "DeveloperProvider", menuName = "Providers/Developer")]
    internal class DeveloperProvider : Provider<DeveloperProvider>
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