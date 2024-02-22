using System;
using Newtonsoft.Json;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Auth.Provider
{
    [CreateAssetMenu(fileName = "Prodvider", menuName = "Providers/AuthProvider", order = 0)]
    public class AuthProvider : Provider<AuthProvider>
    {
        [SerializeField] private HTTPRequestCard LoginAPI; 
        public void Login(string email, string password, bool remember, Action<UnityWebRequest> responseCallback)
        {
            var reqData = LoginAPI.CreateRequestData();
            reqData.BodyJson =  JsonConvert.SerializeObject(new
            {
                email,
                password,
                rememberMe = remember.ToString().ToLower()
            });
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }   
}
