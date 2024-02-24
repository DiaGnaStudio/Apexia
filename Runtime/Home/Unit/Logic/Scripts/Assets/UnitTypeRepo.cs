using Unit.Data;
using UnityEngine;

namespace Unit.Logic.Assets
{
    [CreateAssetMenu(fileName = "UnitTypeRepo", menuName = "Unit/TypeRepo")]
    internal class UnitTypeRepo : ScriptableObject
    {
        [SerializeField] private UnitTypeCard[] typeCards;

        public static UnitTypeRepo PreLoad =>
            Resources.Load<UnitTypeRepo>(typeof(UnitTypeRepo).Name);

        public UnitTypeCard Get(UnitType type)
        {
            foreach (var card in typeCards)
                if (card.Type == type)
                    return card;

            throw new System.NullReferenceException();
        }
    }
}