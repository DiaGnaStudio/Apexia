using Unit.View.Components;
using UnityEngine;
using UPatterns;

namespace Unit.View
{
    public class UnitView : MonoBehaviour
    {
        [field: SerializeField] internal Transform StaticPanel { get; private set; }
        [field: SerializeField] internal UnitFilterPanel FilterPanel { get; private set; }
        [field: SerializeField] internal Pool<UnitInfoPanel> InfoPanelPool { get; private set; }
        [field: SerializeField] internal Pool<UnitMapPanel> MapPanelPool { get; private set; }
        [field: SerializeField] internal Pool<UnitInstallmentsPanel> InstallmentsPanelPool { get; private set; }
        [field: SerializeField] internal UnitBalconyPanel BalconyPanel { get; private set; }
        [field: SerializeField] internal NoneBalconyParent NoneBalconyParent { get; private set; }
    }
}