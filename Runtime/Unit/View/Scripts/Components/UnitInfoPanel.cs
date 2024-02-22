using Gallery.Assets;
using System;
using TMPro;
using Unit.SharedTypes;
using Unit.View.SharedTypes;
using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace Unit.View.Components
{
    internal class UnitInfoPanel : UPanel
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI suitSizeText;
        [SerializeField] private TextMeshProUGUI typeText;
        [SerializeField] private TextMeshProUGUI availabilityText;
        [SerializeField] private TextMeshProUGUI orientationText;
        [SerializeField] private Button installmentsBtn;
        [SerializeField] private Button mapBtn;
        [SerializeField] private Button galleryBtn;
        [SerializeField] private Button unitViewBtn;
        [SerializeField] private Button dollHouseBtn;
        [SerializeField] private Button goToBalconyBtn;

        private UnitCard currentCard;
        private Action<UnitCard> OnClose;

        private bool isInitialized = false;

        public void SetData(UnitCard data)
        {
            nameText.SetText(data.Name);
            suitSizeText.SetText(data.Area.ToString());
            typeText.SetText(data.UnitTypeCard.Name);
            availabilityText.SetText(data.Availability.ToString());
            orientationText.SetText(data.Orientation.ToString());

            currentCard = data;
        }

        public void SetActions(InfoPanelActions actions)
        {
            if (isInitialized) return;
            isInitialized = true;

            installmentsBtn.onClick.AddListener(() => SetInstallmentsAction(actions.OpenInstallments));
            mapBtn.onClick.AddListener(() => SetMapAction(actions.OpenMap));
            galleryBtn.onClick.AddListener(() => SetGalleryAction(actions.OpenGallery));
            unitViewBtn.onClick.AddListener(() => SetUnitViewAction(actions.OpenBalcony));
            dollHouseBtn.onClick.AddListener(() => SetDollHouseAction(actions.OpenDollHouse));
            goToBalconyBtn.onClick.AddListener(SetBalconyAction);

            OnClose = actions.Close;

            void SetInstallmentsAction(Action<Sprite> action) =>
                action.Invoke(currentCard.UnitTypeCard.Payment);

            void SetMapAction(Action<Sprite> action) =>
                action.Invoke(currentCard.UnitTypeCard.Map);

            void SetGalleryAction(Action<GalleryAsset> action) =>
                action.Invoke(currentCard.UnitTypeCard.Gallery);

            void SetUnitViewAction(Action<UnitCard> action) =>
                action.Invoke(currentCard);

            void SetDollHouseAction(Action<UnitCard> action) =>
                action.Invoke(currentCard);

            void SetBalconyAction() =>
                Application.OpenURL(currentCard.UnitTypeCard.ViewLink);
        }

        public override void Hide()
        {
            base.Hide();

            if (currentCard != null)
                OnClose.Invoke(currentCard);
        }
    }
}