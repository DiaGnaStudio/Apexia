using System;
using UnityEngine;
using UnityEngine.UI;

namespace SidePanel.View
{
    [RequireComponent(typeof(Button))]
    internal class CustomerToggle : MonoBehaviour
    {
        private Button button;

        private Action onSwitch;

        private void Awake() =>
            button = GetComponent<Button>();

        private void OnEnable() =>
            button.onClick.AddListener(Click);

        private void OnDisable() =>
            button.onClick.RemoveListener(Click);

        private void Click()
        {
            onSwitch.Invoke();
        }

        public void SetActions(Action onSwitch)
        {
            this.onSwitch = onSwitch;
        }
    }
}
