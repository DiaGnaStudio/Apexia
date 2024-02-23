using Amenities.Assets;
using UCamSystem;
using UnityEngine;

namespace Amenities.Logic
{
    [CreateAssetMenu(fileName = "AmenitiesController", menuName = "Amenities/Controller")]
    public class AmenitiesController : ScriptableObject
    {
        public static AmenitiesController LoadInstance =>
            Resources.Load<AmenitiesController>(typeof(AmenitiesController).Name);

        [field: SerializeField] public AmenitiesInfoAsset[] Assets { get; private set; }
        [SerializeField] private UPointList camPointPrefab;

        public UPointList CamPoint { get; private set; }

        public void Initialize() =>
            CamPoint = Instantiate(camPointPrefab);

        public AmenitiesInfoAsset Get(int index) =>
            Assets[index];

        public string[] GetItemsName() =>
            CamPoint.ItemsName;

        public void Select(int index) =>
            CamPoint.Select(index);
    }
}