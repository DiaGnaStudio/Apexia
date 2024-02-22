using Amenities.Logic;
using Amenities.View;
using UnityEngine;
using UScreens;

namespace Amenities
{
    public static class AmenitiesSystem
    {
        private static bool isInitialize = false;

        private static void Initialize()
        {
            if (isInitialize) return;
            isInitialize = true;

            var logic = AmenitiesController.LoadInstance;
            var view = UScreenRepo.Get<AmnitiesViewController>();

            logic.Initialize();
            view.Initialize(logic.GetItemsName(), logic.Select, logic.Get);
        }

        public static void Show(Transform parent = null)
        {
            Initialize();

            var view = UScreenRepo.Get<AmnitiesViewController>();
            view.SetParent(parent);
            view.Show();
        }

        public static void Hide() =>
            UScreenRepo.Get<AmnitiesViewController>().Hide();
    }
}