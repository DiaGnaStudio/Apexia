using Admin.Provider;
using Admin.Provider.Data;
using System;
using UnityEngine;
namespace ProfileMenu.Core.Modules
{
    internal class ProfileLoader
    {
        private const string BASE_URL = "http://simulixapp.com";

        public void Load(Action<Sprite> onLoadAvatar, Action<string> onLoadName)
        {
            AdminServise.Get(Get, Error);

            void Get(User user)
            {
                if (user.avatar != null)
                    SpriteDownloader.DownloadSprite(BASE_URL + user.avatar.url, onLoadAvatar);
                onLoadName.Invoke(user.fullname);
            }

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}