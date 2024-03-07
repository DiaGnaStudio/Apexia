using Admin.Provider;
using Admin.Provider.Data;
using UnityEngine;

namespace Units.Provider.Test
{
    public class AdminProviderRuntimeTest : MonoBehaviour
    {
        [ContextMenu("Get")]
        private void Get()
        {
            AdminServise.Get(Load, Error);

            void Load(User data) =>
                Debug.Log(data.ToString());

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}