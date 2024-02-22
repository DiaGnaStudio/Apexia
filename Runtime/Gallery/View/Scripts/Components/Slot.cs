using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery.View.Components
{
    internal class Slot : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        [SerializeField] private GameObject boarder;

        public Sprite Image => image.sprite;

        public void Set(Sprite sprite, Action<Slot> onSelect)
        {
            image.sprite = sprite;

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(Click);

            void Click()
            {
                onSelect.Invoke(this);
            }
        }

        internal void Active(bool value)
        {
            image.color = FullAlpha(image.color, value ? 1 : 0.5f);
            boarder.SetActive(value);

            static Color FullAlpha(Color c, float alpha)
            {
                c.a = alpha;
                return c;
            }
        }
    }
}