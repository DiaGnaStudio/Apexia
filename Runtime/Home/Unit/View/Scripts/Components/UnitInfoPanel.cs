using Gallery.Assets;
using System;
using TMPro;
using Unit.Data;
using Unit.View.Components.Info;
using Unit.View.SharedTypes;
using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace Unit.View.Components
{
    internal class UnitInfoPanel : UPanel
    {
        [SerializeField] private BookmarkButton bookmark;
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private InfoText areaText;
        [SerializeField] private InfoText typeText;
        [SerializeField] private InfoText availabilityText;
        //[SerializeField] private InfoText orientationText;
        [SerializeField] private Button installmentsBtn;
        [SerializeField] private Button mapBtn;
        [SerializeField] private Button galleryBtn;
        //[SerializeField] private Button unitViewBtn;
        //[SerializeField] private Button dollHouseBtn;
        [SerializeField] private Button goToBalconyBtn;

        private UnitData currentCard;
        private UnitInstallmentsData currentInstallmentsData;
        private Sprite currentMap;

        private Action<UnitData> OnClose;

        private bool isInitialized = false;

        private static Func<UnitData, bool> CheckBookmarked;
        private static Action<UnitData, bool> OnBookmark;

        public static void SetBookmarkAction(Func<UnitData, bool> checkBookmarked,Action<UnitData, bool> onBookmark)
        {
            CheckBookmarked = checkBookmarked;
            OnBookmark = onBookmark;
        }

        public void SetData(UnitData data, UnitInstallmentsData installmentsData, Sprite map)
        {
            nameText.SetText(data.Name);
            areaText.Set(data.Area.ToString());
            typeText.Set(data.UnitTypeCard.Name);
            availabilityText.Set(data.Availability.ToString());
            //orientationText.Set(data.Orientation.ToString());

            currentCard = data;
            currentInstallmentsData = installmentsData;
            currentMap = map;

            bookmark.SetData(CheckBookmarked(data), ClickOnBookmark);

            if (data.State == State.Negotiable)
                installmentsBtn.gameObject.SetActive(false);
            else
                installmentsBtn.gameObject.SetActive(true);

            void ClickOnBookmark(bool value) => 
                OnBookmark.Invoke(data, value);
        }

        public void SetActions(InfoPanelActions actions)
        {
            if (isInitialized) return;
            isInitialized = true;

            installmentsBtn.onClick.AddListener(() => SetInstallmentsAction(actions.OpenInstallments));
            mapBtn.onClick.AddListener(() => SetMapAction(actions.OpenMap));
            galleryBtn.onClick.AddListener(() => SetGalleryAction(actions.OpenGallery));
            //unitViewBtn.onClick.AddListener(() => SetUnitViewAction(actions.OpenBalcony));
            //dollHouseBtn.onClick.AddListener(() => SetDollHouseAction(actions.OpenDollHouse));
            goToBalconyBtn.onClick.AddListener(SetBalconyAction);

            OnClose = actions.Close;

            void SetInstallmentsAction(Action<UnitInstallmentsData> action) =>
                action.Invoke(currentInstallmentsData);

            void SetMapAction(Action<Sprite> action) =>
                action.Invoke(currentMap);

            void SetGalleryAction(Action<GalleryAsset> action) =>
                action.Invoke(currentCard.UnitTypeCard.Gallery);

            //void SetUnitViewAction(Action<UnitData> action) =>
            //    action.Invoke(currentCard);

            //void SetDollHouseAction(Action<UnitData> action) =>
            //    action.Invoke(currentCard);

            void SetBalconyAction() =>
                Application.OpenURL(currentCard.UnitTypeCard.ViewLink);
        }

        public override void Hide()
        {
            base.Hide();

            if (!currentCard.Equals(null))
                OnClose.Invoke(currentCard);
        }
    }
}