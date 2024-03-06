using Gallery.Assets;
using System;
using Unit.Data;
using Unit.View.Components;
using Unit.View.Components.Info;
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
            View.FilterPanel.Hide();
        }

        public void InitializeFilter(Action<UnitFilter> onUpdate) =>
            View.FilterPanel.SetData(onUpdate);

        public void InitializeInfoPanelActions(Action<GalleryAsset> openGallery, Action<UnitData> openBalcony, Action<UnitData> openDollHouse, Action<UnitData> close)
        {
            InfoPanelActions = new(GetInstallmentsPanel, GetMapPanel, openGallery, openBalcony, openDollHouse, close);

            void GetMapPanel(Sprite map)
            {
                var panel = View.MapPanelPool.GetActive;
                panel.Initialize();
                panel.Show(map);
            }

            void GetInstallmentsPanel(UnitInstallmentsData data)
            {
                var panel = View.InstallmentsPanelPool.GetActive;
                panel.Initialize();
                panel.Show(data);
            }
        }

        public void InitializeBookmark(Action<UnitData, bool> onClick, Func<bool> isIntractable, Func<UnitData, bool> isBookmarked)
        {
            BookmarkButton.Initialize(isIntractable);
            UnitInfoPanel.SetBookmarkAction(isBookmarked, onClick);
        }

        public void Show(UnitData data, UnitInstallmentsData installmentsData, Sprite map)
        {
            var panel = GetInfoPanel();
            panel.SetData(data, installmentsData, map);
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