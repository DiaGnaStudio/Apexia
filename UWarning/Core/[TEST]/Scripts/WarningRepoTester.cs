using UnityEngine;

namespace UWarning.Core.Test
{
    public class WarningRepoTester : MonoBehaviour
    {
        [SerializeField] private string id;

        [ContextMenu("Log")]
        private void Log()
        {
            var card = WarningCardRepo.Get(id);
            Debug.Log($"{card.Id} - {card.Title} - {card.Description}");
        }
    }
}
