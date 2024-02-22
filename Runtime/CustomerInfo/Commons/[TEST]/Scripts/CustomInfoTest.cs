using UnityEngine;

namespace CustomInfo.Test
{
    public class CustomInfoTest : MonoBehaviour
    {
        [SerializeField] private string presenter;
        [SerializeField] private string customer;

        private void Awake()
        {
            Show();
        }

        [ContextMenu("Show")]
        private void Show()
        {
            CustomInfoSystem.Show(presenter, customer);
        }
    }
}