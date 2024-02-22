using UnityEngine;

namespace UWarning.Test
{
    public class WarningSystemTester : MonoBehaviour
    {
        [SerializeField] private string id;

        [ContextMenu("ShowByReject")]
        private void ShowByReject()
        {
            WarningSystem.Show(id, Accept, Reject);

            static void Accept() =>
                Debug.Log("Click on red green");

            static void Reject() =>
                Debug.Log("Click on red button");
        }
    }
}
