using Surronding.SharedTypes;
using SwitchPanel;
using System;
using System.Linq;
using UnityEngine;

namespace Surronding.View.Components
{
    internal class MapGuidePanel : MonoBehaviour
    {
        [SerializeField] private SwitchButtonsPanel selector;

        public void SetFilterAction(Action<MapGuideType[]> onUpdate)
        {
            selector.OnChangedMultiple.AddListener(OnChanged);

            void OnChanged(int[] selectedIndex) =>
                onUpdate.Invoke(selectedIndex.Cast<MapGuideType>().ToArray());
        }
    }
}