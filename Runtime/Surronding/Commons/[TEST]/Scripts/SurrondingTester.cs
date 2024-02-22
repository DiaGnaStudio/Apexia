using UnityEngine;

namespace Surronding.Test
{
    public class SurrondingTester : MonoBehaviour
    {
        private void Awake()
        {
            Show();
        }

        [ContextMenu("Show")]
        private void Show() => SurrondingSystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => SurrondingSystem.Hide();
    }
}