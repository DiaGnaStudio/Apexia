using UnityEngine;

namespace About.Assets
{
    [CreateAssetMenu(fileName = "AboutAsset", menuName = "About/Card")]
    public class AboutAsset : ScriptableObject
    {
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public Sprite[] Items { private set; get; }
        [field: SerializeField] public float SlideShowInterval { get; private set; } = 5;
    }
}