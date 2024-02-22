using System;
using UnityEngine;

namespace SidePanel.View.SharedTypes
{
    public struct PageParentActions
    {
        public PageParentActions(Action<Transform> explorePanel,
                                 Action<Transform> surroundingPanel,
                                 Action<Transform> amenitiePanel,
                                 Action<Transform> unitPanel,
                                 Action<Transform> galleryPanel)
        {
            ExplorePanel = explorePanel;
            SurroundingPanel = surroundingPanel;
            AmenitiePanel = amenitiePanel;
            UnitPanel = unitPanel;
            GalleryPanel = galleryPanel;
        }

        public Action<Transform> ExplorePanel { get; private set; }
        public Action<Transform> SurroundingPanel { get; private set; }
        public Action<Transform> AmenitiePanel { get; private set; }
        public Action<Transform> UnitPanel { get; private set; }
        public Action<Transform> GalleryPanel { get; private set; }
    }

    public struct PageActions
    {
        public PageActions(Action explorePanel,
                           Action surroundingPanel,
                           Action amenitiePanel,
                           Action unitPanel,
                           Action galleryPanel)
        {
            ExplorePanel = explorePanel;
            SurroundingPanel = surroundingPanel;
            AmenitiePanel = amenitiePanel;
            UnitPanel = unitPanel;
            GalleryPanel = galleryPanel;
        }

        public Action ExplorePanel { get; private set; }
        public Action SurroundingPanel { get; private set; }
        public Action AmenitiePanel { get; private set; }
        public Action UnitPanel { get; private set; }
        public Action GalleryPanel { get; private set; }
    }
}
