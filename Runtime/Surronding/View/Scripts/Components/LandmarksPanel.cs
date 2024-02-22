using System;
using UnityEngine;
using UnityEngine.UI;

namespace Surronding.View.Components
{
    internal class LandmarksPanel : MonoBehaviour
    {
        [SerializeField] private Button satelliteBtn;

        public void SetAction(Action action)
        {
            satelliteBtn.onClick.RemoveAllListeners();
            satelliteBtn.onClick.AddListener(action.Invoke);
        }
    }
}