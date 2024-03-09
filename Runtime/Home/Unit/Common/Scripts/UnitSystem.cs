using Gallery;
using System;
using Unit.Data;
using Unit.Logic;
using Unit.View;
using UnityEngine;
using UScreens;

namespace Unit
{
    public static class UnitSystem
    {
        private static readonly UnitController logic;
        private static readonly UnitViewController view;

        static UnitSystem()
        {
            logic = new();
            view = UScreenRepo.Get<UnitViewController>();

            logic.SelectUnit(view.Show);

            view.InitializeFilter(logic.UpdateFilter);
            view.InitializeInfoPanelActions(GallerySystem.Show,
                                            logic.GoToBalcony,
                                            logic.UnSelectUnit);

            logic.SetActiveBuilding(false);
        }

        public static void Initialize(Action<UnitData, bool> onBookmark, Func<int> getClientId, Func<UnitData, bool> isBookmarked, Action onShowBalcony, Action onHideBalcony)
        {
            logic.InitializeBookmark(getClientId);
            view.InitializeBookmark(onBookmark, logic.IsBookmarkEnable, isBookmarked);

            view.InitializeBalconyView(ShowBalcony, HideBalcony);

            void ShowBalcony()
            {
                onShowBalcony.Invoke();
            }

            void HideBalcony()
            {
                logic.SetCameraPoint();
                onHideBalcony.Invoke();
            }
        }

        public static void Show(Transform parent = null)
        {
            if (parent != null)
                view.SetParent(parent);
            logic.SetActiveBuilding(true);
            logic.SetCameraPoint();
            view.Show();
        }

        public static void Hide()
        {
            logic.SetActiveBuilding(false);
            view.Hide();
        }
    }
}