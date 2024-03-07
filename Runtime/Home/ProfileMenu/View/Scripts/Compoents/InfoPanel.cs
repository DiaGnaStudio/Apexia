using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace ProfileMenu.View.Components
{
    internal class InfoPanel : UPanel
    {
        [SerializeField] private Image avatarImage;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private CustomButton profileBTN;
        [SerializeField] private CustomButton settingBTN;
        [SerializeField] private CustomButton signOutBTN;

        public void SetData(Sprite avatar, string name)
        {
            if (avatar != null)
                avatarImage.sprite = avatar;
            nameText.SetText(name);
        }

        public void SetProfileAction(Action action) =>
            profileBTN.SetAction(action);

        public void SetSettingAction(Action action) =>
            settingBTN.SetAction(action);

        public void SetSignOutAction(Action action) =>
            signOutBTN.SetAction(action);
    }
}
