using UnityEngine;

namespace About.Test
{
    public class AboutTester : MonoBehaviour
    {
        [ContextMenu("Show")]
        private void Show() => AboutSystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => AboutSystem.Hide();
    }
}