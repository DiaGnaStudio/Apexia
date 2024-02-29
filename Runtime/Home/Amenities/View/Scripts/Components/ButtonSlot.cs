using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// modules to make amenities buttons work correctly . canvases about showing the details of amenities built up here.
namespace UI.MainMenu.Amenities.Components
{
    internal class ButtonSlot : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text titleText;

        [Header("Sprites")]
        [SerializeField] private Sprite on;
        [SerializeField] private Sprite off;

        private bool isActive;

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