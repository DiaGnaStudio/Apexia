using TMPro;
using UnityEngine;

namespace Min_Max_Slider
{
    public class MinMaxSliderDisplayer : MonoBehaviour
    {
        [SerializeField] private TMP_Text minText;
        [SerializeField] private TMP_Text maxText;
        [SerializeField] private MinMaxSlider slider;

        private void Start() =>
            DisplayValue(slider.Values.minValue, slider.Values.maxValue);

        private void OnEnable() =>
            slider.onValueChanged.AddListener(DisplayValue);

        private void OnDisable() =>
            slider.onValueChanged.RemoveListener(DisplayValue);

        private void DisplayValue(float min, float max)
        {
            minText.SetText(Show(min));
            //displayer.SetText(string.Format("{0}-{1}", min, max));
        }

        private string Show(float value)
        {
            string result;
            string[] ScoreNames = new string[] { "", "k", "M", "B", "T", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az", "ba", "bb", "bc", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bk", "bl", "bm", "bn", "bo", "bp", "bq", "br", "bs", "bt", "bu", "bv", "bw", "bx", "by", "bz", };
            int i;

            for (i = 0; i < ScoreNames.Length; i++)
                if (value < 900)
                    break;
                else value = Mathf.Floor(value / 100f) / 10f;

            if (value == Mathf.Floor(value))
                result = value.ToString() + ScoreNames[i];
            else result = value.ToString("F1") + ScoreNames[i];
            return result;
        }
    }
}