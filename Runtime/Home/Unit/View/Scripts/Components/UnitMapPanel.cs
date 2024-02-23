using UnityEngine;
using UnityEngine.UI;
using UScreens;

namespace Unit.View.Components
{
    internal class UnitMapPanel : UPanel
    {
        [SerializeField] private Image image;

        public void Show(Sprite map)
        {
            image.sprite = map;
            base.Show();
        }
    }
}