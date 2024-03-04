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

        private int id;
        private bool bookmarked = false;

        private static Action<int, bool> OnClick;
        private static Func<bool> IsIntractable;
        private static Func<int, bool> IsBookmarked;

        private void OnEnable()
        {
            button.interactable = IsIntractable();
            button.onClick.AddListener(CLick);

            bookmarked = IsBookmarked(id);
            UpdateView();
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(CLick);
        }

        private void CLick()
        {
            OnClick.Invoke(id, !bookmarked);
            UpdateView();
        }

        private void UpdateView()
        {
            image.sprite = bookmarked ? on : off;
        }

        public static void Initialize(Action<int, bool> onClick, Func<bool> isIntractable, Func<int, bool> isBookmarked)
        {
            OnClick = onClick;
            IsIntractable = isIntractable;
            IsBookmarked = isBookmarked;
        }

        public void SetData(int id) =>
            this.id = id;
    }
}