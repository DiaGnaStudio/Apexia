using UnityEngine;
using UnityEngine.UI;

namespace CustomerInfo.View.Test
{
    public class CustomerInfoRuntimeTest : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            CustomerInfoSystem.Initialzie(SignOut, null, null, null);

            void SignOut() => Debug.Log("Click on sign out");
        }

        private void OnEnable()
        {
            button.onClick.AddListener(Show);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Show);
        }

        [ContextMenu(nameof(Show))]
        private void Show() =>
            CustomerInfoSystem.Show();
    }
}
