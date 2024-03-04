using System;
using UnityEngine.Networking;

namespace Bookmark.Provider
{
    public static class BookmarkService
    {
        private static readonly BookmarkProvider provider;

        static BookmarkService() =>
            provider = BookmarkProvider.Load;

        public static void Bookmark(int[] unitIds, int clientId, Action OnLoad, Action<string> onError)
        {
            provider.Bookmark(unitIds, clientId, LoginCallback);

            void LoginCallback(UnityWebRequest callbackReq)
            {
                if (callbackReq.error != null)
                {
                    onError.Invoke(callbackReq.downloadHandler.text);
                    return;
                }

                OnLoad.Invoke();
            }
        }

        public static void Bookmark(int unitId, int clientId, Action OnLoad, Action<string> onError)
        {
            Bookmark(new int[1] { unitId }, clientId, OnLoad, onError);
        }
    }
}