using CustomerInfo.View.Profile;
using CustomerInfo.View.SignIn;
using UnityEngine;

namespace CustomerInfo.View
{
    public class CustomerInfoView : MonoBehaviour
    {
        [field: SerializeField] internal ProfilePanel ProfilePanel { get; private set; }
        [field: SerializeField] internal SignInPanel SignInPanel { get; private set; }
    }
}
