using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery.View.Components
{
    internal class GalleryButton : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button prevBtn;
        [SerializeField] private Button nextBtn;

        public void SetButtons(Action onNext, Action onPrev)
        {
            AddListener(prevBtn, onPrev);
            AddListener(nextBtn, onNext);

            void AddListener(Button button, Action action)
            {
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(action.Invoke);
            }
        }
    }
}