using SidePanel.View.SharedTypes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SidePanel.View.Components
{
    internal class PagesPanel : MonoBehaviour
    {
        [field: SerializeField] public Transform PageParent { get; private set; }

        [Header("Buttons")]
        [SerializeField] private PageButton exploreBtn;
        [SerializeField] private PageButton surroundingBtn;
        [SerializeField] private PageButton amenitiesBtn;
        [SerializeField] private PageButton unitBtn;
        [SerializeField] private PageButton galleryBtn;

        private List<PageButton> buttons = new();

        private Action OnGlobalClick;

        private PageButton lastPage;

        private void Awake()
        {
            buttons = new List<PageButton>
            {
                exploreBtn,
                surroundingBtn,
                amenitiesBtn,
                unitBtn,
                galleryBtn
            };

            lastPage = exploreBtn;
        }

        public void SetOpenActions(PageParentActions actions)
        {
            exploreBtn.SetAction(OnExploreClick);
            surroundingBtn.SetAction(OnSurroundingClick);
            amenitiesBtn.SetAction(OnAmenitieClick);
            unitBtn.SetAction(OnUnitClick);
            galleryBtn.SetAction(OnGalleryClick);

            void OnExploreClick(PageButton button) =>
                OnClick(button, actions.ExplorePanel);

            void OnSurroundingClick(PageButton button) =>
                OnClick(button, actions.SurroundingPanel);

            void OnAmenitieClick(PageButton button) =>
                OnClick(button, actions.AmenitiePanel);

            void OnUnitClick(PageButton button) =>
                OnClick(button, actions.UnitPanel);

            void OnGalleryClick(PageButton button) =>
                OnClick(button, actions.GalleryPanel);

            void OnClick(PageButton button, Action<Transform> action)
            {
                lastPage = button;
                OnGlobalClick.Invoke();
                action.Invoke(PageParent);
                ActivateButtons(button);

                void ActivateButtons(PageButton target)
                {
                    foreach (var button in buttons)
                        button.Active(button == target);
                }
            }
        }

        internal void SetGlobalAction(Action onClick) =>
            OnGlobalClick = onClick;

        public void ShowDefault() =>
            lastPage.InvokeButton();
    }
}