using Auth.Provider.Data;
using UnityEngine;

namespace Auth.Provider.Test
{
    public class AuthProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private string email;
        [SerializeField] private string password;
        [SerializeField] private bool remember;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Login();
        }

        [ContextMenu("Login")]
        private void Login()
        {
            AuthService.Login(email, password, remember, Load, Error);

            void Load(UserData data) =>
                Debug.Log(data.ToString());

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}