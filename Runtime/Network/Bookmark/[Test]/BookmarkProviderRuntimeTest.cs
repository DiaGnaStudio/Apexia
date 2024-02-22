using UnityEngine;

namespace Bookmark.Provider.Test
{
    public class BookmarkProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private int idclientId;
        [SerializeField] private int[] unitIds;

        [ContextMenu("Bookmark")]
        private void Bookmark()
        {
            BookmarkService.Bookmark(unitIds, idclientId, Load, Error);

            void Load() =>
                Debug.Log("");

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}