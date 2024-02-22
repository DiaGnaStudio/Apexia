using CustomerInfo.Data;
using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace CustomerInfo.View.Test
{
    public class CustomerInfoViewRuntimeTest : MonoBehaviour
    {
        [SerializeField] private Button profileButton;
        [SerializeField] private Button signUpButton;
        private CustomerInfoViewController view;

        private void Awake()
        {
            view = UScreenRepo.Get<CustomerInfoViewController>();
            view.Initialize(SignOut, GetUser, Share, ClearAll, Delete, GetData, Login, GuestLogin);

            void SignOut() => Debug.Log("Click on sign out");
            (Sprite avatar, string username) GetUser() => (null, "NEW USER");
            void Share() => Debug.Log("Click on share");
            void ClearAll() => Debug.Log("Click on clear all");
            void Delete(UnifInfo info) => Debug.Log($"Delete the bookmard ({info})");
            UnifInfo[] GetData() => new UnifInfo[0];
            void Login() => Debug.Log("Click on login");
            void GuestLogin() => Debug.Log("Click on guest login");
        }

        private void OnEnable()
        {
            profileButton.onClick.AddListener(ShowProfile);
            signUpButton.onClick.AddListener(ShowSignUp);
        }

        private void OnDisable()
        {
            profileButton.onClick.RemoveListener(ShowProfile);
            signUpButton.onClick.RemoveListener(ShowSignUp);
        }

        [ContextMenu(nameof(ShowProfile))]
        private void ShowProfile() =>
            view.ShowProfile();

        [ContextMenu(nameof(ShowSignUp))]
        private void ShowSignUp() =>
            view.ShowSignUp();
    }
}
