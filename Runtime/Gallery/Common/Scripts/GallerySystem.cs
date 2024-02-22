using Gallery.Assets;
using Gallery.Logic;
using Gallery.View;
using UnityEngine;
using UScreens;

namespace Gallery
{
    public static class GallerySystem
    {
        private static GalleryController logic;
        private static bool isInitialized = false;

        private static void Initialize()
        {
            if (isInitialized) return;
            isInitialized = true;

            logic = GalleryController.LoadInstance;
            var view = UScreenRepo.Get<GalleryViewController>();

            view.SetSprites(logic.GetSprites, logic.UpdateIndex, logic.GetStarterIndex);
            view.InitializeButtons(logic.ToNext, logic.ToPrev, logic.GetCurrentIndex);
        }

        public static void Show(Transform parent = null)
        {
            Initialize();

            UScreenRepo.Get<GalleryViewController>().Show();
        }

        public static void Show(GalleryAsset asset)
        {
            Initialize();

            logic.ChangeAsset(asset);

            UScreenRepo.Get<GalleryViewController>().Show();
        }

        public static void Hide() =>
            UScreenRepo.Get<GalleryViewController>().Hide();

        public static Transform GetStaticObject() => null;
    }
}