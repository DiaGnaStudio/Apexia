using System;
using UnityEngine;
using UnityEngine.UI;

namespace SidePanel.View.Components
{
    internal class DaySlider : MonoBehaviour
    {
        [SerializeField] private Slider _dayCycleSlider;
        [SerializeField] private float _dayCycleSliderDefaultValue = .3f;

        private void Awake()
        {
            _dayCycleSlider.value = _dayCycleSliderDefaultValue;
        }

        public void Initialize(Action<float> onValueChanged) =>
            _dayCycleSlider.onValueChanged.AddListener(onValueChanged.Invoke);

        public void SetVisibleState(bool value) =>
            _dayCycleSlider.gameObject.SetActive(value);
    }
}