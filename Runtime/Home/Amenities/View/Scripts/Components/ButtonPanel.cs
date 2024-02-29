using System;
using UnityEngine;
using UPatterns;

// modules to make amenities buttons work correctly . canvases about showing the details of amenities built up here.
namespace UI.MainMenu.Amenities.Components
{
    internal class ButtonPanel : MonoBehaviour
    {
        [SerializeField] private Pool<ButtonSlot> itemPool;

        public void Initialize(string[] items, Action<int> onSelect)
        {
            itemPool.DeactiveAllInstance();

            for (int i = 0; i < items.Length; i++)
                itemPool.GetActive.Show(items[i], Click);

            void Click(int index)
            {
                for (int i = 0; i < itemPool.ActiveItems.Length; i++)
                    itemPool.ActiveItems[i].Active(i == index);

                onSelect.Invoke(index);
            }
        }

        private void OnEnable()
        {
            if (itemPool.ActiveItems.Length > 0)
                itemPool.ActiveItems[0].ForceInvoke();
        }
    }
}