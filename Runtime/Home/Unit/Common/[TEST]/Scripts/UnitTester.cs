using UnityEngine;

namespace Unit.Test
{
    public class UnitTester : MonoBehaviour
    {
        private void Awake()
        {
            Show();
        }

        [ContextMenu("Show")]
        private void Show() => UnitSystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => UnitSystem.Hide();
    }
}