using UnityEngine;

namespace SidePanel.Test
{
    public class SidePanelTest : MonoBehaviour
    {
        private void Awake()
        {
            SidePanelSystem.Initialize(ChangeDayNight, Exit, ShowMenus);

            void ChangeDayNight(float value) => Debug.Log("Day night slider's value changed to " + value);
            void Exit() => Debug.Log("Exit!");
            void ShowMenus() => Debug.Log("Return to menu");
        }

        private void Start() => Show();

        [ContextMenu("Show")]
        private void Show() => SidePanelSystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => SidePanelSystem.Hide();
    }
}
