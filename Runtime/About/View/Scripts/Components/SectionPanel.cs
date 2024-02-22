using About.Assets;
using System;
using UnityEngine;
using UPatterns;

namespace About.View.Components
{
    internal class SectionPanel : MonoBehaviour
    {
        [SerializeField] private Pool<SectionButton> buttonPool;

        private Action<AboutAsset> OnClick;

        public void SetClickAction(Action<AboutAsset> onClick) => 
            OnClick = onClick;

        public void SetCards(AboutAsset[] asset)
        {
            buttonPool.DeactiveAllInstance();

            foreach(var card in asset)
            {
                buttonPool.GetActive.SetData(card, Click);
            }

            Click(buttonPool.ActiveItems[0]);

            void Click(SectionButton clicked)
            {
                foreach(var card in buttonPool.ActiveItems)
                    card.Active(card == clicked);

                OnClick.Invoke(clicked.Asset);
            }
        }
    }
}