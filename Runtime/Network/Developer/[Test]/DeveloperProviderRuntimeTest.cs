using Developer.Provider.Data;
using System.Linq;
using UnityEngine;

namespace Developer.Provider.Test
{
    public class DeveloperProviderRuntimeTest : MonoBehaviour
    {
        [ContextMenu("GetAll")]
        private void GetAll()
        {
            DeveloperService.GetAll(Load, Error);

            void Load(DeveloperData[] data) =>
                Debug.Log(string.Join("\n", data.Select(item => $"{{\n{item}\n}}")));

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}