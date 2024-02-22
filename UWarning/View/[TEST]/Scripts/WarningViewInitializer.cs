using UWarning.Data;
using UnityEngine;
using UScreens;

namespace UWarning.View.Test
{
    public class WarningViewInitializer : MonoBehaviour
    {
        [SerializeField] private WarningCard card;

        private void Awake()
        {
            UScreenRepo.Get<WarningViewController>().Hide();
        }

        [ContextMenu("Show")]
        private void Show()
        {
            UScreenRepo.Get<WarningViewController>().Show(card, Accept, Reject);

            static void Accept() =>
                Debug.Log("Click on red green");

            static void Reject() =>
                Debug.Log("Click on red button");
        }
    }
}
