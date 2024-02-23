using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// modules to make amenities buttons work correctly . canvases about showing the details of amenities built up here.
namespace UI.MainMenu.Amenities.Components
{
    internal class ButtonSlot : MonoBehaviour
    {
        [SerializeField] private Button _btn;
        [SerializeField] private TMP_Text _text;

        public void Show(string title, Action<int> onLook)
        {
            gameObject.SetActive(true);
            _text.SetText(title);
            _btn.onClick.AddListener(() => onLook.Invoke(transform.GetSiblingIndex()));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}