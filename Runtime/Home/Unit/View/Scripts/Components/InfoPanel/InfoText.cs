using TMPro;
using UnityEngine;

namespace Unit.View.Components.Info
{
    internal class InfoText : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void Set(string value) =>
            text.SetText(value);
    }
}