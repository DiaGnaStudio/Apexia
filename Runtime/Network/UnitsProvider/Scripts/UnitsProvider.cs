using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Units.Provider
{
    [CreateAssetMenu(fileName = "UnitsProdvider", menuName = "Providers/UnitsProvider", order = 0)]
    public class UnitsProvider : Provider<UnitsProvider>
    {
        [SerializeField] private HTTPRequestCard GetAllAPI;
        public void GetAll(Action<UnityWebRequest> responseCallback)
        {
            var reqData = GetAllAPI.CreateRequestData();
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }

        [SerializeField] private HTTPRequestCard GetByIdAPI; 
        public void GetById(int id, Action<UnityWebRequest> responseCallback)
        {
            var reqData = GetByIdAPI.CreateRequestData();
            reqData.AppendUrl(id.ToString());
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }   
}
