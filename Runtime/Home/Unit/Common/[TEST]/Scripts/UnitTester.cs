using Unit.Data;
using UnityEngine;

namespace Unit.Test
{
    public class UnitTester : MonoBehaviour
    {
        public int clientId;

        private void Awake()
        {
            UnitSystem.Initialize(BookmarkUnit, GetClientId, (data) => false, EMPTY, EMPTY);
            Show();

            void BookmarkUnit(UnitData data, bool isBookmarked)
            {
                if (isBookmarked)
                    Debug.Log($"Bookmark unit -> {data}");
                else
                    Debug.Log($"Unbookmark unit -> {data}");
            }

            int GetClientId() => clientId;

            void EMPTY()
            {

            }
        }

        [ContextMenu("Show")]
        private void Show() => UnitSystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => UnitSystem.Hide();
    }
}