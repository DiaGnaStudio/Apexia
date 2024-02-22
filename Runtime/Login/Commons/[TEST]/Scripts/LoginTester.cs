using UnityEngine;

namespace Login.Test
{
    public class LoginTester : MonoBehaviour
    {
        [ContextMenu("Show")]
        private void Show() => LoginSystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => LoginSystem.Hide();
    }
}