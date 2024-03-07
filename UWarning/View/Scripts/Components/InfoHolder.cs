using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UWarning.View.Conponents
{
    internal class InfoHolder : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text descriptionText;

        public void SetIcon(Sprite sprite)
        {
            icon.gameObject.SetActive(sprite != null);
            icon.sprite = sprite;
        }

        public void SetDescription(string description)
        {
            descriptionText.SetText(description);
            descriptionText.gameObject.SetActive(!string.IsNullOrEmpty(description));
        }
    }
}
