using UnityEngine;

namespace ClientConfigs.Provider.Test
{
    public class ClientConfigsProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private string firstName;
        [SerializeField] private string lastName;
        [SerializeField] private ulong phone;

        [ContextMenu("Send")]
        private void Send()
        {
            ClientConfigsService.Send(firstName, lastName, phone, Load, Error);

            void Load() =>
                Debug.Log("");

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}