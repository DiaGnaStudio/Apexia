using UnityEngine;

namespace Order.Provider.Test
{
    public class OrderProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private int idclientId;
        [SerializeField] private int unitId;

        [ContextMenu("Bookmark")]
        private void Bookmark()
        {
            OrderService.Send(unitId, idclientId, Load, Error);

            void Load() =>
                Debug.Log("ShareSuccessfully");

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}