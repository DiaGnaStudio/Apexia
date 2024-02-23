using UnityEngine;

namespace Unit.SharedTypes
{
    [CreateAssetMenu(fileName = "UnitCard", menuName = "Unit/Card", order = 0)]
    public class UnitCard : ScriptableObject
    {
        [field: SerializeField] public string Name { private set; get; }
        [field: SerializeField] public int Area { private set; get; }
        [field: SerializeField] public int Floor { private set; get; }
        [field: SerializeField] public int Price { private set; get; }
        [field: SerializeField] public UnitTypeCard UnitTypeCard { private set; get; }
        [field: SerializeField] public Orientation Orientation { private set; get; }
        [field: SerializeField] public Availabilty Availability { private set; get; }
    }
}