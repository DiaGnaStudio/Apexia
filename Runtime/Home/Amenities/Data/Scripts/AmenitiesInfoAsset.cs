using UnityEngine;

namespace Amenities.Assets
{
    [CreateAssetMenu(fileName = "AmenitiesInfoAsset", menuName = "Amenities/Card")]
    public class AmenitiesInfoAsset : ScriptableObject
    {
        public string title;
        public string description;
        public Sprite preview;
    }
}