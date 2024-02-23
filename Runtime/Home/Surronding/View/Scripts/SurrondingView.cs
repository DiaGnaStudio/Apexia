using Surronding.View.Components;
using UnityEngine;

namespace Surronding.View
{
    public class SurrondingView : MonoBehaviour
    {
        [field: SerializeField] internal Transform StaticPanel { get; private set; }
        [field: SerializeField] internal FilterPanel FilterPanel { get; private set; }
        [field: SerializeField] internal LandmarksPanel LandmarksPanel { get; private set; }
        [field: SerializeField] internal SatellitePanel SatellitePanel { get; private set; }
        [field: SerializeField] internal ButtonPanel OptionPanel { get; private set; }
    }
}