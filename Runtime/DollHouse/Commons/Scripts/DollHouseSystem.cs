using DollHouse.Logic;
using DollHouse.View;
using Unit.SharedTypes;
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
                view.Show(card.Name, card.UnitTypeCard.Type.ToString(), card.Area);
                view.SetCloseAction(DollHouseController.Unload);
            }
        }

        public static void Show(UnitCard card)
        {
            DollHouseController.Load(card);
        }
    }
}