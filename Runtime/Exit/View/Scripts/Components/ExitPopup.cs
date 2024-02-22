using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace Exit.View.Components
{
    internal class ExitPopup : UPanel
    {
        [SerializeField] private Button cancelBtn;
        [SerializeField] private Button exitBtn;

        private void Awake()
        {
            cancelBtn.onClick.AddListener(Hide);
            exitBtn.onClick.AddListener(Exit);

            static void Exit()
            {
                Application.Quit();
            }
        }
    }
}