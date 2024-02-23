using System;
using UnityEngine;
using UnityEngine.UI;

namespace DollHouse.View.Components
{
    internal class DollHouseClose : MonoBehaviour
    {
        [SerializeField] private Button button;

        public void SetAction(Action action) =>
            button.onClick.AddListener(action.Invoke);
    }
}