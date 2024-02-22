using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomerInfo.View.Profile.Components
{
    internal class UserInfo : MonoBehaviour
    {
        [SerializeField] private Image avatarImage;
        [SerializeField] private TMP_Text usernameText;
        [SerializeField] private Button signOutButton;

        public void SetData(Sprite avatar, string username)
        {
            if (avatar != null)
                avatarImage.sprite = avatar;

            usernameText.SetText(username);
        }

        public void SetSignOutAction(Action action) =>
            signOutButton.onClick.AddListener(action.Invoke);
    }
}
