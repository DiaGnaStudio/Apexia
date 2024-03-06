using System;
using UnityEngine;
using UnityEngine.UI;

namespace Unit.View.Components.Info
{
    internal class BookmarkButton : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button button;

        [Header("Sprites")]
        [SerializeField] private Sprite on;
        [SerializeField] private Sprite off;

        private bool bookmarked = false;

        private Action<bool> OnClick;
        private static Func<bool> IsIntractable;

        private void OnEnable()
        {
            button.interactable = IsIntractable();
            button.onClick.AddListener(CLick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(CLick);
        }

        private void CLick()
        {
            bookmarked = !bookmarked;
            OnClick.Invoke(bookmarked);
            UpdateView();
        }

        private void UpdateView()
        {
            image.sprite = bookmarked ? on : off;
        }

        public static void Initialize(Func<bool> isIntractable)
        {
            IsIntractable = isIntractable;
        }

        public void SetData(bool isBookmarked,Action<bool> onClick)
        {
            OnClick = onClick;
            bookmarked = isBookmarked;
            UpdateView();
        }
    }
}