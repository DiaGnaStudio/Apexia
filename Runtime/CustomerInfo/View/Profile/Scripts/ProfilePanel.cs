using CustomerInfo.Data;
using CustomerInfo.View.Profile.Components;
using System;
using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace CustomerInfo.View.Profile
{
    public class ProfilePanel : UPanel
    {
        [SerializeField] private UserInfo userInfo;
        [SerializeField] private CustomButton shareButton;
        [SerializeField] private CustomButton clearAllButton;
        [SerializeField] private BookmarkCreator creator;
        [SerializeField] private Button closeBtn;

        private Func<OrderInfo[]> DataGetter;
        private Func<(Sprite avatar, string username)> UserDataGetter;

        public void SetCustomerData(Func<(Sprite avatar, string username)> getter) =>
            UserDataGetter = getter;

        public void SetBookmarksGetter(Func<OrderInfo[]> getter) =>
            DataGetter = getter;

        public void SetActions(Action signOut, Action share, Action clearAll, Action<OrderInfo> deleteBookmark)
        {
            userInfo.SetSignOutAction(signOut);
            shareButton.SetAction(share);
            clearAllButton.SetAction(clearAll);
            UnitInfoSlot.SetDeleteAction(deleteBookmark);
        }

        public override void Show()
        {
            base.Show();

            creator.SetDatas(DataGetter());

            var data = UserDataGetter();
            userInfo.SetData(data.avatar, data.username);
        }

        public void SetCloseAction(Action action) =>
            closeBtn.onClick.AddListener(action.Invoke);
    }
}
