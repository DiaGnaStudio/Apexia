using System;
using TMPro;
using UnityEngine;

namespace CustomerInfo.View.SignIn.Components
{
    [RequireComponent(typeof(TMP_InputField))]
    internal class TextInputField : MonoBehaviour
    {
        private TMP_InputField input;

        private void Awake() => 
            input = GetComponent<TMP_InputField>();

        public string GetValue() =>
            input.text;

        public void SetChangeInput(Action<string> changeInput)
        {
            input.onValueChanged.AddListener(changeInput.Invoke);
        }

        public void Clear() => 
            input.text = string.Empty;
    }
}