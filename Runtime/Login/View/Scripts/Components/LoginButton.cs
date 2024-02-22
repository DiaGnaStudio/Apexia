using System;
using UnityEngine;
using UnityEngine.UI;

namespace Login.View.Components
{
    [RequireComponent(typeof(Button))]
    internal class LoginButton : MonoBehaviour
    {
        private Button button;
        private Action OnClick;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(Click);
        }

        public void SetAction(Action action) =>
            OnClick = action;

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
                Click();
        }

        private void Click()
        {
            OnClick.Invoke();
        }

        public void SetIntractable(bool intractable) => 
            button.interactable = intractable;
    }
}