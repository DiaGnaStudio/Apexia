using Gallery;
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

            void OpenDollHouse(UnitData card)
            {
                SceneManager.LoadScene(2);
            }
        }

        public static void Show(Transform parent = null)
        {
            if (parent != null)
                view.SetParent(parent);
            logic.Show();
            view.Show();
        }

        public static void Hide() =>
            view.Hide();
    }
}