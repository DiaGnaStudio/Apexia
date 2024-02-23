using System;
using UnityEngine;
using UnityEngine.UI;

namespace SidePanel.View
{
    [RequireComponent(typeof(Button))]
    internal class PageToggle : MonoBehaviour
    {
        [SerializeField] private Transform pageParent;

        private Button button;
        private bool isActive;

        private Action<Transform> on;
        private Action off;

        private void Awake() =>
            button = GetComponent<Button>();

        private void OnEnable() =>
            button.onClick.AddListener(Click);

        private void OnDisable() =>
            button.onClick.RemoveListener(Click);

        private void Click()
        {
            if (isActive)
                off.Invoke();
            else
                on.Invoke(pageParent);

            isActive = !isActive;
        }

        public void SetActions(Action<Transform> doOn, Action doOff)
        {
            on = doOn;
            off = doOff;
        }
    }
}
