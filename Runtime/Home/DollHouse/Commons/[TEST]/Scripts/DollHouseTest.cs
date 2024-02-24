using Unit.Data;
using UnityEngine;

namespace DollHouse.Test
{
    public class DollHouseTest : MonoBehaviour
    {
        [SerializeField] private UnitCard card;

        [ContextMenu("Show")]
        public void Show() =>
            DollHouseSystem.Show(card);
    }
}