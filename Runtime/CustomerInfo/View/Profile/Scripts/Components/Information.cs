using TMPro;
using UnityEngine;

namespace CustomerInfo.View.Profile.Components
{
    internal class Information : MonoBehaviour
    {
        [SerializeField] private TMP_Text value;

        public void SetText(string text) =>
            value.SetText(text);
    }
}
