using Surronding.SharedTypes;
using SwitchPanel;
using System;
using System.Linq;
using UnityEngine;

namespace Surronding.View.Components
{
    internal class DistancePanel : MonoBehaviour
    {
        [SerializeField] private SwitchButtonsPanel selector;

        public void SetFilterAction(Action<WalkingDistanceType[]> action)
        {
            selector.OnChangedMultiple.AddListener(OnChanged);

            void OnChanged(int[] selectedIndex) =>
                action.Invoke(selectedIndex.Cast<WalkingDistanceType>().ToArray());
        }
    }
}