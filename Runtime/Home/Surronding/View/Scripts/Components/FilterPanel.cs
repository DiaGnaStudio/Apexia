using Surronding.SharedTypes;
using System;
using UnityEngine;

namespace Surronding.View.Components
{
    internal class FilterPanel : MonoBehaviour
    {
        [SerializeField] private DistancePanel distancePanel;
        [SerializeField] private MapGuidePanel mapGuidePanel;

        private readonly SurrendingFilter filter = new();
        
        public void SetData(Action<SurrendingFilter> onUpdate)
        {
            distancePanel.SetFilterAction(UpdateDistance);
            mapGuidePanel.SetFilterAction(UpdateMapGuide);

            void UpdateDistance(WalkingDistanceType[] updatedData) =>
                onUpdate.Invoke(filter.UpdateDistances(updatedData));

            void UpdateMapGuide(MapGuideType[] updatedData) => 
                onUpdate.Invoke(filter.UpdateMapGuide(updatedData));
        }
    }
}