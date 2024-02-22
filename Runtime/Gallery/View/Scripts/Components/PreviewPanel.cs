using UnityEngine;
using UnityEngine.UI;

namespace Gallery.View.Components
{
    internal class PreviewPanel : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetImage(Sprite sprite) =>
            image.sprite = sprite;
    }
}