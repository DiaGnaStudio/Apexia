using Gallery;
using System;
using Unit.Data;
using Unit.Logic;
using Unit.View;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                                            OpenDollHouse,
                                            logic.UnSelectUnit);

            logic.SetActiveBuilding(false);

            void OpenDollHouse(UnitData card) => 
                SceneManager.LoadScene(2);
        }

        public static void Initialize(Action<UnitData, bool> onBookmark, Func<int> getClientId, Func<UnitData, bool> isBookmarked)
        {
            logic.InitializeBookmark(getClientId);
            view.InitializeBookmark(onBookmark, logic.IsBookmarkEnable, isBookmarked);
        }

        public static void Show(Transform parent = null)
        {
            if (parent != null)
                view.SetParent(parent);
            logic.SetActiveBuilding(true);
            logic.Show();
            view.Show();
        }

        public static void Hide()
        {
            logic.SetActiveBuilding(false);
            view.Hide();
        }
    }
}