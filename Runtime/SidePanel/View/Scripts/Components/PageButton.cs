using System;
using UnityEngine;
using UnityEngine.UI;

namespace SidePanel.View.Components
{
    [RequireComponent(typeof(Button))]
    public class PageButton : MonoBehaviour
    {
        private Button button;

        [Header("Theme")]
        [SerializeField] private SpriteChanger icon;
        [SerializeField] private SpriteChanger boarder;

        private bool isActive;

        private void Awake()
        {
            button = GetComponent<Button>();
        }

        public void SetAction(Action<PageButton> action)
        {
            button.onClick.AddListener(OnClick);

            void OnClick()
            {
                if (isActive) return;
                action.Invoke(this);
            }
        }

        internal void Active(bool value)
        {
            isActive = value;
            icon.SetSprite(value);
            boarder.SetSprite(value);
        }

        public void InvokeButton() => 
            button.onClick.Invoke();

        [System.Serializable]
        private struct SpriteChanger
        {
            [SerializeField] private Image image;
            [SerializeField] private Sprite on;
            [SerializeField] private Sprite off;

            public readonly void SetSprite(bool value) =>
                image.sprite = value ? on : off;
        }
    }
}