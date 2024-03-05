using ClientConfigs.Provider.Data;
using System.Text.RegularExpressions;
using UnityEngine;

namespace ClientConfigs.Provider.Test
{
    public class ClientConfigsProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private string firstName;
        [SerializeField] private string lastName;
        [SerializeField] private string phone;
        [SerializeField] private string email;

        [ContextMenu("Send")]
        private void Send()
        {
            ClientConfigsService.Send(firstName, lastName, phone, email, Load, Error);

            void Load(Client client) =>
                Debug.Log(client.ToString());

            void Error(string message) =>
                Debug.LogError(message);
        }

        [ContextMenu("Verify")]
        public void Verify()
        {
            Debug.Log($"Email: {ValidateEmail(email)}");
        }

        bool ValidateEmail(string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                  + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$");
        }
    }
}