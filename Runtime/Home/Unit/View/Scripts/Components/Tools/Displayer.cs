using TMPro;
using UnityEngine;

namespace Min_Max_Slider
{
    [DisallowMultipleComponent]
    internal class Displayer : MonoBehaviour
    {
        [SerializeField] private MinMaxSlider slider;

        [SerializeField] private TMP_Text minText;
        [SerializeField] private TMP_Text maxText;

        private void Start() =>
            DisplayValue(slider.Values.minValue, slider.Values.maxValue);

        private void OnEnable() =>
            slider.onValueChanged.AddListener(DisplayValue);

        private void OnDisable() =>
            slider.onValueChanged.RemoveListener(DisplayValue);

        private void DisplayValue(float min, float max)
        {
            minText.SetText(Convert(min));
            maxText.SetText(Convert(max));
        }

        protected virtual string Convert(float value) =>
            value.ToString();
    }
}