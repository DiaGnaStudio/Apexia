using Unit.Logic.Components;
using UnityEngine;

namespace Unit.Logic
{
    [CreateAssetMenu(fileName = "UnitController", menuName = "Unit/Controller")]
    public class UnitController : ScriptableObject
    {
        public static UnitController LoadInstance =>
                    Resources.Load<UnitController>(typeof(UnitController).Name);

        public UnitFilterController FilterController { get; private set; }

        public Building Building { get; private set; }

        public void Initialize()
        {
            Building = FindObjectOfType<Building>();

            FilterController = new UnitFilterController(Building.ApplyFilter);
        }
    }
}