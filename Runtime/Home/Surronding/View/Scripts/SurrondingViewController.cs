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
            View.StaticPanel.Initialize();

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

            View.StaticPanel.Show();
            View.SatellitePanel.Hide();
        }

        public override void Hide()
        {
            View.StaticPanel.Hide();
            base.Hide();
        }

        public void ChangeParent(Transform parent) =>
            View.StaticPanel.transform.SetParent(parent, false);
    }
}