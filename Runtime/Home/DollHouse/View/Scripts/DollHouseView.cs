using DollHouse.View.Components;
using UnityEngine;

namespace DollHouse.View
{
    public class DollHouseView : MonoBehaviour
    {
        [field: SerializeField] internal DollHouseInfoPanel InfoPanel { get; private set; }
        [field: SerializeField] internal DollHouseClose CloseButton { get; private set; }
    }
}