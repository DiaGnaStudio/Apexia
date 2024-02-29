using Amenities.Assets;
using System;
using UnityEngine;
using UScreens;

// modules to make amenities buttons work correctly . canvases about showing the details of amenities built up here.
namespace Amenities.View
{
    public class AmnitiesViewController : UScreenGeneric<AmnitiesViewController, AmnitiesView>
    {
        private Action<int> OnSelect;
        private Func<int, AmenitiesInfoAsset> GetInfo;

        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.InfoPanel.Initialize();
        }

        public void Initialize(string[] items, Action<int> onSelect, Func<int, AmenitiesInfoAsset> getInfo)
        {
            OnSelect = onSelect;
            GetInfo = getInfo;
            View.ButtonPanel.Initialize(items, GoToPoint);
        }

        public override void Show()
        {
            base.Show();
            View.StaticPanel.gameObject.SetActive(true);
            GoToPoint(0);
        }

        public override void Hide()
        {
            View.StaticPanel.gameObject.SetActive(false);
            View.InfoPanel.Hide();
            base.Hide();
        }

        private void GoToPoint(int index)
        {
            OnSelect?.Invoke(index);
            View.InfoPanel.Show();
            //View.InfoPanel.Set(GetInfo(index));
        }

        public void SetParent(Transform parent) =>
            View.StaticPanel.SetParent(parent, false);
    }
}