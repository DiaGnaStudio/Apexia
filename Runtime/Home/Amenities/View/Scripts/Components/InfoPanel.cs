using Amenities.Assets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UScreens;

// modules to make amenities buttons work correctly . canvases about showing the details of amenities built up here.
namespace UI.MainMenu.Amenities.Components
{
    internal class InfoPanel : UPanel
    {
        [SerializeField] private TextMeshProUGUI titleTxt;
        [SerializeField] private Image previewImg;
        [SerializeField] private TextMeshProUGUI descriptionTxt;

        public void Set(AmenitiesInfoAsset asset) =>
            Set(asset.title, asset.description, asset.preview);

        public void Set(string title, string description, Sprite preview)
        {
            titleTxt.text = title;
            descriptionTxt.text = description;
            previewImg.sprite = preview;
        }
    }
}