using DollHouse.Logic;
using DollHouse.View;
using Unit.Data;
using UScreens;

namespace DollHouse
{
    public static class DollHouseSystem
    {
        static DollHouseSystem()
        {
            DollHouseController.SetLoadAction(OnCompleteLoad);

            static void OnCompleteLoad(UnitCard card)
            {
                var view = UScreenRepo.Get<DollHouseViewController>();
                view.Show(card.Data.Name, card.Data.UnitTypeCard.Type.ToString(), card.Data.Area);
                view.SetCloseAction(DollHouseController.Unload);
            }
        }

        public static void Show(UnitCard card)
        {
            DollHouseController.Load(card);
        }
    }
}