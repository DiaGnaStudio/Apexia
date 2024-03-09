using Amenities;
using CustomerInfo;
using Explore;
using Gallery;
using ProfileMenu;
using SidePanel.View;
using Surronding;
using System;
using Unit;
using UnityEngine;
using UScreens;
using static ObjectRelativeActivator;

namespace SidePanel
{
    public static class SidePanelSystem// rename to main menu
    {
        private static readonly SidePanelViewContoller view;

        static SidePanelSystem()
        {
            view = UScreenRepo.Get<SidePanelViewContoller>();

            view.SetOpenPages(OpenExplore,
                              OpenSurronding,
                              OpenAmenities,
                              OpenUnit,
                              GallerySystem.Show);

            view.SetClosePages(SurrondingSystem.Hide,
                               AmenitiesSystem.Hide,
                               UnitSystem.Hide,
                               GallerySystem.Hide);

            view.SetProfileAction(ProfileMenuSystem.Show, ProfileMenuSystem.Hide);
            view.SetCustomerAction(CustomerInfoSystem.Switch);

            void OpenExplore(Transform parent) =>
                Open(ExploreSystem.Show, parent, TabType.Explore);

            void OpenSurronding(Transform parent) =>
                Open(SurrondingSystem.Show, parent, TabType.Surronding);

            void OpenAmenities(Transform parent) =>
                Open(AmenitiesSystem.Show, parent, TabType.Ameneties);

            void OpenUnit(Transform parent) =>
                Open(UnitSystem.Show, parent, TabType.Unit);

            void Open(Action<Transform> onOpen, Transform parent, TabType type)
            {
                onOpen(parent);
                Change(type);
            }
        }

        public static void Initialize(Action<float> onChangeDay, Action exit, Action openHome) =>
            view.Initialize(onChangeDay, exit, openHome);

        public static void Show()
        {
            ProfileMenuSystem.Hide();
            view.Show();
        }

        public static void Hide() =>
            view.Hide();
    }
}