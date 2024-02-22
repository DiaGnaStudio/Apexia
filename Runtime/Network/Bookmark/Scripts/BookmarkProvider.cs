using Newtonsoft.Json;
using System;
using UHTTP;
using UnityEngine;
using UnityEngine.Networking;

namespace Bookmark.Provider
{
    [CreateAssetMenu(fileName = "BookmarkProvider", menuName = "Providers/Bookmark")]
    public class BookmarkProvider : Provider<BookmarkProvider>
    {
        [SerializeField] private HTTPRequestCard bookmarkAPI;

        public void Bookmark(int[] unitIds, int clientId, Action<UnityWebRequest> responseCallback)
        {
            var reqData = bookmarkAPI.CreateRequestData();
            reqData.BodyJson = JsonConvert.SerializeObject(new
            {
                units_id = unitIds,
                client_id = clientId
            });
            var req = reqData.CreateRequest();
            req.SetCallback(responseCallback);
            req.Send();
        }
    }
}