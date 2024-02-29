using UnityEngine;

namespace ProfileMenu.Test
{
    public class ProfileMenuTest : MonoBehaviour
    {
        private void Awake()
        {
            ProfileMenuSystem.Initialize(Profile, Setting, SignOut);
            Show();

            void Profile() => Debug.Log("Click on Profile.");
            void Setting() => Debug.Log("Click on Setting.");
            void SignOut() => Debug.Log("Click on SignOut.");
        }

        [ContextMenu("Show")]
        private void Show()
        {
            ProfileMenuSystem.Show();
        }
    }
}