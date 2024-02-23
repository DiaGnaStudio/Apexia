using Gallery.Assets;
using UnityEngine;

namespace Unit.SharedTypes
{
    [CreateAssetMenu(fileName = "UnitTypeCard", menuName = "Unit/TypeCard", order = 1)]
    public class UnitTypeCard : ScriptableObject
    {
        [field: SerializeField] public string Name { private set; get; }
        [field: SerializeField] public Sprite Map { private set; get; }
        [field: SerializeField] public Sprite Payment { private set; get; }
        [field: SerializeField] public GalleryAsset Gallery { private set; get; }
        [field: SerializeField] public UnitType Type { private set; get; }
        [field: SerializeField] public GameObject DollHousePrefab { private set; get; }
        [field: SerializeField] public string ViewLink { private set; get; }
    }
}