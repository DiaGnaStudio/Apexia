using UnityEngine;

namespace DollHouse.Logic
{
    internal class DollHouseHolder : MonoBehaviour
    {
        [SerializeField] private Transform objectParent;

        public void Show(GameObject prefab) =>
            Instantiate(prefab, objectParent);
    }
}