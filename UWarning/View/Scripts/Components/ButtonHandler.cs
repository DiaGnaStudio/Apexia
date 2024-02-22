using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UWarning.View.Conponents
{
    internal class ButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button acceptButton;
        private TMP_Text acceptText;
        [SerializeField] private Button rejectButton;
        private TMP_Text rejectText;

        private Action OnHide;

        private void Awake()
        {
            acceptText = acceptButton.GetComponentInChildren<TMP_Text>();
            rejectText = rejectButton.GetComponentInChildren<TMP_Text>();
        }

        public void SetHideAction(Action hide) =>
            OnHide = hide;

        public void SetAcceptInfo(bool isActive, string text, Action action)
        {
            acceptButton.gameObject.SetActive(isActive);

            if (!isActive) return;

            SetAction(acceptButton, action);
            acceptText.SetText(text);
        }

        public void SetRejectInfo(bool isActive, string text, Action action)
        {
            rejectButton.gameObject.SetActive(isActive);

            if (!isActive) return;

            SetAction(rejectButton, action);
            rejectText.SetText(text);
        }

        private void SetAction(Button button, Action action)
        {
            button.onClick.AddListener(OnClick);

            void OnClick()
            {
                action?.Invoke();
                OnHide.Invoke();
            }
        }
    }
}
