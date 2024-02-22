using Projects.Provider.Data;
using System.Linq;
using UnityEngine;

namespace Projects.Provider.Test
{
    public class ProjectsProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private int id;

        [ContextMenu("GetById")]
        private void GetById()
        {
            ProjectsService.GetById(id, Load, Error);

            void Load(ProjectsData[] data) =>
                Debug.Log(string.Join("\n", data.Select(item => $"{{\n{item}\n}}")));

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}