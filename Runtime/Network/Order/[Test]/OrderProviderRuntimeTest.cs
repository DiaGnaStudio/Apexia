using UnityEngine;

namespace Order.Provider.Test
{
    public class OrderProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private int idclientId;
        [SerializeField] private int[] unitIds;

        [ContextMenu("Bookmark")]
        private void Bookmark()
        {
            OrderService.Send(unitIds, idclientId, Load, Error);

            void Load() =>
                Debug.Log("");

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}