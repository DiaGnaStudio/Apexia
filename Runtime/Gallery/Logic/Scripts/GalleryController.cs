using Gallery.Assets;
using UnityEngine;

namespace Gallery.Logic
{
    [CreateAssetMenu(fileName = "GalleryController", menuName = "Gallery/Controller")]
    public class GalleryController : ScriptableObject
    {
        [SerializeField] private GalleryAsset asset;

        [SerializeField] private int indexStarter;

        private int currentIndex = -1;
        
        public static GalleryController LoadInstance =>
                    Resources.Load<GalleryController>(typeof(GalleryController).Name);

        private Sprite[] Sprites => asset.Items;

        public void ChangeAsset(GalleryAsset asset) =>
            this.asset = asset;

        public Sprite[] GetSprites() => Sprites;

        public Sprite ToNext() =>
            Select(currentIndex < Sprites.Length - 1 ? currentIndex + 1 : 0);

        public Sprite ToPrev() =>
            Select(currentIndex > 0 ? currentIndex - 1 : Sprites.Length - 1);

        private Sprite Select(int index)
        {
            currentIndex = index;
            return Sprites[index];
        }

        public int GetCurrentIndex() => currentIndex;
        public int GetStarterIndex() => indexStarter;

        public void UpdateIndex(Sprite sprite)
        {
            for (int i = 0; i < Sprites.Length; i++)
            {
                if (sprite == Sprites[i])
                {
                    currentIndex = i;
                    break;
                }
            }

        }
    }
}