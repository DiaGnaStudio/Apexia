using Exit.View;
using UnityEngine;
using UScreens;

namespace Exit.Test
{
    public class ExitSystemRuntimeTest :MonoBehaviour
    {
        private void Awake()
        {
            Show();
        }

        [ContextMenu(nameof(Show))]
        private void Show() =>
            ExitSystem.Show();
    }
}