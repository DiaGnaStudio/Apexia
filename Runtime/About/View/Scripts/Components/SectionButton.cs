using About.Assets;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace About.View.Components
{
    [RequireComponent(typeof(Button))]
    internal class SectionButton : MonoBehaviour
    {
        private Button button;
        private TMP_Text titleText;

        [Header("Sprites")]
        [SerializeField] private Sprite on;
        [SerializeField] private Sprite off;

        private bool isActive;

        public AboutAsset Asset { get; private set; }

        private void Awake()
        {
            button = GetComponent<Button>();
            titleText = button.GetComponentInChildren<TMP_Text>();
        }

        public void SetData(AboutAsset asset, Action<SectionButton> action)
        {
            Asset = asset;

            titleText.SetText(asset.Title);

            button.onClick.RemoveAllListeners();
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
            button.image.sprite = value ? on : off;
        }
    }
}