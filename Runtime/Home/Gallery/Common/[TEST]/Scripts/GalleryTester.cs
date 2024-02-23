using UnityEngine;

namespace Gallery.Test
{
    public class GalleryTester : MonoBehaviour
    {
        [ContextMenu("Show")]
        private void Show() => GallerySystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => GallerySystem.Hide();
    }
}