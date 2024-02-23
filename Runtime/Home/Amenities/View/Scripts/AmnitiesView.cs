using UI.MainMenu.Amenities.Components;
using UnityEngine;

namespace Amenities.View
{
    public class AmnitiesView : MonoBehaviour
    {
        [field: SerializeField] internal Transform StaticPanel { get; private set; }
        [field: SerializeField] internal InfoPanel InfoPanel { get; private set; }
        [field: SerializeField] internal ButtonPanel ButtonPanel { get; private set; }
    }
}