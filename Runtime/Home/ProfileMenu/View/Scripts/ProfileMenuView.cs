using ProfileMenu.View.Components;
using UnityEngine;
using UScreens;

namespace ProfileMenu.View
{
    public class ProfileMenuView : MonoBehaviour
    {
        [field: SerializeField] internal UPanel StaticPanel { get; private set; }
        [field: SerializeField] internal InfoPanel InfoPanel { get; private set; }
    }
}