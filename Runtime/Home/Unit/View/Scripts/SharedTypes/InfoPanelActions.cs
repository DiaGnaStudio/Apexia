using Gallery.Assets;
using System;
using Unit.SharedTypes;
using UnityEngine;

namespace Unit.View.SharedTypes
{
    internal class InfoPanelActions
    {
        public Action<Sprite> OpenInstallments;
        public Action<Sprite> OpenMap;
        public Action<GalleryAsset> OpenGallery;
        public Action<UnitCard> OpenBalcony;
        public Action<UnitCard> OpenDollHouse;
        public Action<UnitCard> Close;

        public InfoPanelActions(Action<Sprite> openInstallments,
                                Action<Sprite> openMap,
                                Action<GalleryAsset> openGallery,
                                Action<UnitCard> openBalcony,
                                Action<UnitCard> openDollHouse,
                                Action<UnitCard> close)
        {
            OpenInstallments = openInstallments;
            OpenMap = openMap;
            OpenGallery = openGallery;
            OpenBalcony = openBalcony;
            OpenDollHouse = openDollHouse;
            Close = close;
        }
    }
}