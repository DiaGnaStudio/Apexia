using Newtonsoft.Json;
using System;
using Units.Provider.Data;
using UnityEngine;
using UnityEngine.Networking;

namespace Units.Provider
{
    public class UnitServices : MonoBehaviour
    {
        private static readonly UnitsProvider provider;

        static UnitServices() =>
            provider = UnitsProvider.Load;

        public static void GetById(int id, Action<UnitData> onLoadProfile, Action<string> onError)
        {
            provider.GetById(id, Callback);

            void Callback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var data = JsonConvert.DeserializeObject<UnitData>(callbackReq.downloadHandler.text);

                onLoadProfile.Invoke(data);
            }
        }

        public static void GetAll(Action<UnitData[]> onLoadProfile, Action<string> onError)
        {
            provider.GetAll(Callback);

            void Callback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var data = JsonConvert.DeserializeObject<UnitData[]>(callbackReq.downloadHandler.text);

                onLoadProfile.Invoke(data);
            }
        }
    }
}