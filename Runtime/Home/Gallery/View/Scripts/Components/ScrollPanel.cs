using System;
using UnityEngine;
using UPatterns;

namespace Gallery.View.Components
{
    internal class ScrollPanel : MonoBehaviour
    {
        [SerializeField] private Pool<Slot> itemPool;

        private Action<Sprite> OnSelect;
        private Func<Sprite[]> SpriteGetter;
        private Func<int> GetFirstIndex;

        private bool isSet = false;

        private void OnEnable()
        {
            if (SpriteGetter == null) return;

            SetSprites();
        }

        private void OnDisable()
        {
            isSet = false;
        }

        public void Initialize(Func<Sprite[]> getter, Action<Sprite> onSelect, Func<int> getFirstIndex)
        {
            SpriteGetter = getter;
            OnSelect = onSelect;
            GetFirstIndex = getFirstIndex;

            SetSprites();
        }

        public void SetOn(int index)
        {
            for (int i = 0; i < itemPool.ActiveItems.Length; i++)
                itemPool.ActiveItems[i].Active(i == index);
        }

        private void SetSprites()
        {
            if (isSet) return;
            isSet = true;

            itemPool.DeactiveAllInstance();

            Sprite[] sprites = SpriteGetter();
            for (int i = 0; i < sprites.Length; i++)
                itemPool.GetActive.Set(sprites[i], ClickOnSlot);

            SetOn(GetFirstIndex());

            void ClickOnSlot(Slot slot)
            {
                for (int i = 0; i < itemPool.ActiveItems.Length; i++)
                {
                    if (itemPool.ActiveItems[i] == slot)
                        itemPool.ActiveItems[i].Active(true);
                    else
                        itemPool.ActiveItems[i].Active(false);
                }

                OnSelect.Invoke(slot.Image);
            }
        }
    }
}