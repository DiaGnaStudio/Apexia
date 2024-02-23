using Surronding.SharedTypes;
using System;
using UnityEngine;
using UScreens;

namespace Surronding.View
{
    public class SurrondingViewController : UScreenGeneric<SurrondingViewController, SurrondingView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.SatellitePanel.Initialize();
            View.LandmarksPanel.SetAction(View.SatellitePanel.Show);
        }

        public void InitializeFilter(Action<SurrendingFilter> onUpdate) =>
            View.FilterPanel.SetData(onUpdate);

        public void InitializeOptions(string[] items, Action<int> onSelect) => 
            View.OptionPanel.Initialize(items, onSelect.Invoke);

        public override void Show()
        {
            base.Show();

            View.StaticPanel.gameObject.SetActive(true);
            View.SatellitePanel.Hide();
        }

        public override void Hide()
        {
            View.StaticPanel.gameObject.SetActive(false);
            base.Hide();
        }

        public void ChangeParent(Transform parent) =>
            View.StaticPanel.SetParent(parent, false);
    }
}