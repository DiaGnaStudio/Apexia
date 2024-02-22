using Newtonsoft.Json;
using Projects.Provider.Data;
using System;
using UnityEngine.Networking;

namespace Projects.Provider
{
    public static class ProjectsService
    {
        private static readonly ProjectsProvider provider;

        static ProjectsService() =>
            provider = ProjectsProvider.Load;

        public static void GetById(int id, Action<ProjectsData[]> onLoadProfile, Action<string> onError)
        {
            provider.GetById(id, Callback);

            void Callback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                var data = JsonConvert.DeserializeObject<RootObject>(callbackReq.downloadHandler.text);

                onLoadProfile.Invoke(data.projects);
            }
        }

        private class RootObject
        {
            public int status;
            public ProjectsData[] projects;
        }
    }
}