using Gallery;
using Unit.Logic;
using Unit.SharedTypes;
using Unit.View;
using UnityEngine;
using UnityEngine.SceneManagement;
using UScreens;

namespace Unit
{
    public static class UnitSystem
    {
        static UnitSystem()
        {
            var logic = UnitController.LoadInstance;
            var view = UScreenRepo.Get<UnitViewController>();

            logic.Initialize();

            logic.Building.InitializeUnits(view.Show);

            view.InitializeFilter(logic.FilterController.Update);
            view.InitializeInfoPanelActions(GallerySystem.Show,
                                            logic.Building.GoToBalcony,
                                            OpenDollHouse,
                                            logic.Building.UnSelectUnit);

            void OpenDollHouse(UnitCard card)
            {
                SceneManager.LoadScene(2);
            }
        }

        public static void Show(Transform parent = null)
        {
            var view = UScreenRepo.Get<UnitViewController>();
            if (parent != null)
                view.SetParent(parent);
            view.Show();
        }

        public static void Hide() =>
            UScreenRepo.Get<UnitViewController>().Hide();
    }
}