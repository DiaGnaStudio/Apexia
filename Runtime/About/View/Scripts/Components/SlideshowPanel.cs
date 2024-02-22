using About.Assets;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace About.View.Components
{
    internal class SlideshowPanel : MonoBehaviour
    {
        [SerializeField] private Image preview;

        private Sprite[] images;

        private int currentIndex = 0;
        private Coroutine slideShowCoroutine;

        private WaitForSeconds waiter;

        public void Initialize(AboutAsset asset)
        {
            waiter = new(asset.SlideShowInterval);
            images = asset.Items;

            if (images.Length > 0)
            {
                preview.sprite = images[currentIndex];
                StartSlideShow();
            }
        }

        void StartSlideShow()
        {
            StopSlideShow();
            slideShowCoroutine = StartCoroutine(SlideShow());
        }

        void StopSlideShow()
        {
            if (slideShowCoroutine != null)
            {
                StopCoroutine(slideShowCoroutine);
                slideShowCoroutine = null;
            }
        }

        IEnumerator SlideShow()
        {
            while (true)
            {
                yield return waiter;
                ShowNextImage();
            }
        }

        void ShowNextImage()
        {
            currentIndex = (currentIndex + 1) % images.Length;
            UpdateImage();
        }

        void ShowPreviousImage()
        {
            currentIndex = (currentIndex - 1 + images.Length) % images.Length;
            UpdateImage();
        }

        void UpdateImage()
        {
            preview.sprite = images[currentIndex];
        }

        // Manual control methods
        public void NextImage()
        {
            ShowNextImage();
            StopSlideShow();
        }

        public void PreviousImage()
        {
            ShowPreviousImage();
            StopSlideShow();
        }

        public void PauseSlideShow()
        {
            StopSlideShow();
        }

        public void ResumeSlideShow()
        {
            StartSlideShow();
        }
    }

}