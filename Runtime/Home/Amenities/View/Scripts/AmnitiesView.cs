using UI.MainMenu.Amenities.Components;
using UnityEngine;
using UScreens;

namespace Amenities.View
{
    public class AmnitiesView : MonoBehaviour
    {
        [field: SerializeField] internal UPanel StaticPanel { get; private set; }
        [field: SerializeField] internal InfoPanel InfoPanel { get; private set; }
        [field: SerializeField] internal ButtonPanel ButtonPanel { get; private set; }
    }
}