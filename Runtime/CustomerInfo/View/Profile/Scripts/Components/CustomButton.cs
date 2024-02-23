﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace CustomerInfo.View.Profile.Components
{
    [RequireComponent(typeof(Button))]
    internal class CustomButton : MonoBehaviour
    {
        private Button button;

        private void Awake() =>
            button = GetComponent<Button>();

        public void SetAction(Action action)
        {
            button.onClick.AddListener(Click);

            void Click() =>
                action.Invoke();
        }
    }
}