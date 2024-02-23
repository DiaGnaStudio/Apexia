using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace Unit.View.Components
{
    internal class UnitInstallmentsPanel : UPanel
    {
        [SerializeField] private Image image;

        public void Show(Sprite map)
        {
            image.sprite = map;
            base.Show();
        }
    }
}