using Gallery.Assets;
using System;
using Unit.Data;
using UnityEngine;

namespace Unit.View.SharedTypes
{
    internal class InfoPanelActions
    {
        public Action<UnitInstallmentsData> OpenInstallments;
        public Action<Sprite> OpenMap;
        public Action<GalleryAsset> OpenGallery;
        public Action<UnitData> OpenBalcony;
        //public Action<UnitData> OpenDollHouse;
        public Action<UnitData> Close;

        public InfoPanelActions(Action<UnitInstallmentsData> openInstallments,
                                Action<Sprite> openMap,
                                Action<GalleryAsset> openGallery,
                                Action<UnitData> openBalcony,
                                //Action<UnitData> openDollHouse,
                                Action<UnitData> close)
        {
            OpenInstallments = openInstallments;
            OpenMap = openMap;
            OpenGallery = openGallery;
            OpenBalcony = openBalcony;
            //OpenDollHouse = openDollHouse;
            Close = close;
        }
    }
}