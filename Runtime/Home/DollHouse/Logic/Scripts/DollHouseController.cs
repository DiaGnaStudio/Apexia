using System;
using Unit.Data;
using Object = UnityEngine.Object;

namespace DollHouse.Logic
{
    public static class DollHouseController
    {
        private static DollHouseLoader loader;

        public static void SetLoadAction(Action<UnitCard> onCompleteLoad)
        {
            loader = new(OnCompleteLoad);

            void OnCompleteLoad(UnitCard card)
            {
                var holder = Object.FindObjectOfType<DollHouseHolder>();
                onCompleteLoad.Invoke(card);
                holder.Show(card.Data.UnitTypeCard.DollHousePrefab);
            }
        }

        public static void Load(UnitCard unitCard) =>
            loader.Load(unitCard);

        public static void Unload() =>
            loader.UnLoad();
    }
}