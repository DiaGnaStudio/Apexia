using Login.View.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Login.View
{
    public class LoginView : MonoBehaviour
    {
        [field:SerializeField] internal LoginPanel Panel { get; private set; }
        [field: SerializeField] internal Button CloseBTN { get; private set; }
    }
}