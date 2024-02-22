using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Projects.Provider
{
    [CreateAssetMenu(fileName = "ProjectsProdvider", menuName = "Providers/Projects")]
    public class ProjectsProvider : Provider<ProjectsProvider>
    {
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
