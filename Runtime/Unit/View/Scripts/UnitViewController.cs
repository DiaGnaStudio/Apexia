using Gallery.Assets;
using System;
using Unit.SharedTypes;
using Unit.View.Components;
using Unit.View.SharedTypes;
using UnityEngine;
using UScreens;

namespace Unit.View
{
    public class UnitViewController : UScreenGeneric<UnitViewController, UnitView>
    {
        private InfoPanelActions InfoPanelActions;

        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.FilterPanel.Initialize();
        }

        public void InitializeFilter(Action<UnitFilter> onUpdate) =>
            View.FilterPanel.SetData(onUpdate);

        public void InitializeInfoPanelActions(Action<GalleryAsset> openGallery, Action<UnitCard> openBalcony, Action<UnitCard> openDollHouse, Action<UnitCard> close)
        {
            InfoPanelActions = new(GetInstallmentsPanel, GetMapPanel, openGallery, openBalcony, openDollHouse, close);

            void GetMapPanel(Sprite map)
            {
                var panel = View.MapPanelPool.GetActive;
                panel.Initialize();
                panel.Show(map);
            }

            void GetInstallmentsPanel(Sprite sprite)
            {
                var panel = View.InstallmentsPanelPool.GetActive;
                panel.Initialize();
                panel.Show(sprite);
            }
        }

        public void Show(UnitCard card)
        {
            var panel = GetInfoPanel();
            panel.SetData(card);
            panel.Show();

            UnitInfoPanel GetInfoPanel()
            {
                var panel = View.InfoPanelPool.GetActive;
                panel.Initialize();
                panel.SetActions(InfoPanelActions);
                return panel;
            }
        }

        public override void Show()
        {
            base.Show();

            View.StaticPanel.gameObject.SetActive(true);
            View.FilterPanel.Show();
            View.InfoPanelPool.DeactiveAllInstance();
            View.MapPanelPool.DeactiveAllInstance();
            View.InstallmentsPanelPool.DeactiveAllInstance();
        }

        public override void Hide()
        {
            View.StaticPanel.gameObject.SetActive(false);
            View.FilterPanel.Hide();
            View.InfoPanelPool.DeactiveAllInstance();
            View.MapPanelPool.DeactiveAllInstance();
            View.InstallmentsPanelPool.DeactiveAllInstance();
            base.Hide();
        }

        public void SetParent(Transform parent) =>
            View.StaticPanel.SetParent(parent, false);
    }
}