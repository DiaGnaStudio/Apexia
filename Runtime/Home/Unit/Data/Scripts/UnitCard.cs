using UnityEngine;

namespace Unit.Data
{
    [CreateAssetMenu(fileName = "UnitCard", menuName = "Unit/Card", order = 0)]
    public class UnitCard : ScriptableObject
    {
        [SerializeField] private int Id;
        [SerializeField] private string Name;
        [SerializeField] private int Area;
        [SerializeField] private int Floor;
        [SerializeField] private int Price;
        [SerializeField] private UnitTypeCard UnitTypeCard;
        [SerializeField] private Orientation Orientation;
        [SerializeField] private Availabilty Availability;
        [SerializeField] private State State;

        public UnitData Data => new(Id, Name, Area, Floor, Price, UnitTypeCard, Orientation, Availability, State);
    }
}