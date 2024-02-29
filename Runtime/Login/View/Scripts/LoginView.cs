using Login.View.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Login.View
{
    public class LoginView : MonoBehaviour
    {
        [field: SerializeField] internal TextInputField Email { get; private set; }
        [field: SerializeField] internal TextInputField Password { get; private set; }
        [field: SerializeField] internal LoginButton LoginBTN { get; private set; }
        [field: SerializeField] internal Button CloseBTN { get; private set; }
    }
}