using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// modules to make amenities buttons work correctly . canvases about showing the details of amenities built up here.
namespace Surronding.View.Components
{
    [RequireComponent(typeof(Button))]
    internal class ButtonSlot : MonoBehaviour
    {
        private Button button;
        private TMP_Text titleText;

        [Header("Sprites")]
        [SerializeField] private Sprite on;
        [SerializeField] private Sprite off;

        private bool isActive;

        private void Awake()
        {
            button = GetComponent<Button>();
            titleText = button.GetComponentInChildren<TMP_Text>();
        }

        public void Show(string title, Action<int> onLook)
        {
            gameObject.SetActive(true);
            titleText.SetText(title);
            button.onClick.AddListener(OnClick);

            void OnClick()
            {
                if (isActive) return;
                onLook.Invoke(transform.GetSiblingIndex());
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ForceInvoke()
        {
            button.onClick.Invoke();
        }

        internal void Active(bool value)
        {
            isActive = value;
            button.image.sprite = value ? on : off;
        }
    }
}