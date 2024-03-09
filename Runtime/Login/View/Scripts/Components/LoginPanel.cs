using UnityEngine;
using UScreens;

namespace Login.View.Components
{
    internal class LoginPanel : UPanel
    {
        [field: SerializeField] internal TextInputField Email { get; private set; }
        [field: SerializeField] internal TextInputField Password { get; private set; }
        [field: SerializeField] internal LoginButton LoginBTN { get; private set; }
    }
}