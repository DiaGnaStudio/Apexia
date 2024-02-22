using SidePanel.View.Components;
using UnityEngine;
using UnityEngine.UI;

namespace SidePanel.View
{
    public class SidePanelView : MonoBehaviour
    {
        [field: SerializeField] internal PagesPanel PagesPanel { get; private set; }
        [field: SerializeField] internal DaySlider DaySlider { get; private set; }
		[field: SerializeField] internal CustomAnimation Animation { get; private set; }

        [field: SerializeField] internal Button HomeBtn { get; private set; }
        [field: SerializeField] internal Button ExitBtn { get; private set; }
        [field: SerializeField] internal PageToggle ProfileBtn { get; private set; }
        [field: SerializeField] internal CustomerToggle CustomerBtn { get; private set; }
    }
}