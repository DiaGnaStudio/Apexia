using CustomerInfo.View.SignIn.Components;
using System;
using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace CustomerInfo.View.SignIn
{
    public class SignInPanel : UPanel
    {
        [SerializeField] private TextInputField firstNameInput;
        [SerializeField] private TextInputField lastNameInput;
        [SerializeField] private TextInputField phoneInput;
        [SerializeField] private TextInputField emailInput;
        [SerializeField] private LoginButton nextBtn;
        [SerializeField] private Button guestBtn;
        [SerializeField] private Button closeBtn;

        private Action OnLogin;

        public void OnChangeName(Action<string> onfirstNameChanged, Action<string> onlastNameChanged)
        {
            firstNameInput.SetChangeInput(onfirstNameChanged);
            lastNameInput.SetChangeInput(onlastNameChanged);
        }

        public void OnChangePhone(Action<string> onChanged) =>
            phoneInput.SetChangeInput(onChanged);

        public void OnChangeEmail(Action<string> onChanged) =>
            emailInput.SetChangeInput(onChanged);

        public void SetLoginAction(Action action)
        {
            nextBtn.SetAction(Click);

            void Click()
            {
                action.Invoke();
                OnLogin?.Invoke();
            }
        }

        public void SetGuestAction(Action action)
        {
            guestBtn.onClick.AddListener(Click);

            void Click()
            {
                action.Invoke();
                OnLogin.Invoke();
            }
        }

        public void SetButtonIntractable(bool value) =>
            nextBtn.SetIntractable(value);

        public void SetGlobalLoginAction(Action action)
        {
            OnLogin = Action;

            void Action()
            {
                action.Invoke();
                Hide();
            }
        }

        public void ClearInput()
        {
            firstNameInput.Clear();
            lastNameInput.Clear();
            phoneInput.Clear();
            emailInput.Clear();
        }

        public void SetCloseAction(Action action) =>
            closeBtn.onClick.AddListener(action.Invoke);
    }
}
