using UnityEngine;

namespace Gallery.Assets
{
    [CreateAssetMenu(fileName = "GalleryAsset", menuName = "Gallery/Card")]
    public class GalleryAsset : ScriptableObject
    {
        [field: SerializeField] public Sprite[] Items { private set; get; }
    }
}