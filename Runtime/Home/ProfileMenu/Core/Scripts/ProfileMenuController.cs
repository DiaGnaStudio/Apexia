using ProfileMenu.Core.Modules;
using System;
using UnityEngine;

namespace ProfileMenu.Core
{
    public class ProfileMenuController
    {
        private readonly ProfileLoader loaderAPI = new();

        private Sprite avatar;
        private string name;

        private readonly Action<Sprite, string> OnLoad;

        public ProfileMenuController(Action<Sprite, string> onLoad)
        {
            OnLoad = onLoad;
        }

        internal void Load()
        {
            if (!string.IsNullOrEmpty(name) && avatar != null)
            {
                OnLoad.Invoke(avatar, name);
                return;
            }

            loaderAPI.Load(SetAvatar, SetName);

            void SetAvatar(Sprite avatar)
            {
                this.avatar = avatar;
                CheckLoad();
            }

            void SetName(string name)
            {
                this.name = name;
                CheckLoad();
            }

            void CheckLoad()
            {
                if (string.IsNullOrEmpty(name)) return;
                if (avatar == null) return;

                OnLoad.Invoke(avatar, name);
            }
        }

        internal void SignOut()
        {
            avatar = null;
            name = string.Empty;
        }
    }
}