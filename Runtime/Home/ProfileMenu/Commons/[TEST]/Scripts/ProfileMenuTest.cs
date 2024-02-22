using UnityEngine;

namespace ProfileMenu.Test
{
    public class ProfileMenuTest : MonoBehaviour
    {
        private void Awake()
        {
            Show();
        }

        [ContextMenu("Show")]
        private void Show()
        {
            ProfileMenuSystem.Show();
        }
    }
}