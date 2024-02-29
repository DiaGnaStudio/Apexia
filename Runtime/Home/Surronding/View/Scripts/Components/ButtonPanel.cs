using System;
using UnityEngine;
using UPatterns;

// modules to make amenities buttons work correctly . canvases about showing the details of amenities built up here.
namespace Surronding.View.Components
{
    internal class ButtonPanel : MonoBehaviour
    {
        [SerializeField] private Pool<ButtonSlot> buttonPool;

        public void Initialize(string[] items, Action<int> onSelect)
        {
            buttonPool.DeactiveAllInstance();

            for (int i = 0; i < items.Length; i++)
                buttonPool.GetActive.Show(items[i], Click);

            void Click(int index)
            {
                for (int i = 0; i < buttonPool.ActiveItems.Length; i++)
                    buttonPool.ActiveItems[i].Active(i == index);

                onSelect.Invoke(index);
            }
        }

        private void OnEnable()
        {
            if (buttonPool.ActiveItems.Length > 0)
                buttonPool.ActiveItems[0].ForceInvoke();
        }
    }
}