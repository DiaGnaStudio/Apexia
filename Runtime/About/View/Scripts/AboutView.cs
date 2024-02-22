using About.View.Components;
using UnityEngine;
using UnityEngine.UI;

namespace About.View
{
    public class AboutView : MonoBehaviour
    {
        [field: SerializeField] internal SectionPanel SectionPanel { get; private set; }
        [field: SerializeField] internal ControllerPanel ControllerPanel { get; private set; }
        [field: SerializeField] internal SlideshowPanel SlideshowPanel { get; private set; }
        [field: SerializeField] internal CustomButton CustomerInfoButton { get; private set; }
        [field: SerializeField] internal CustomButton ProjectButton { get; private set; }
        [field: SerializeField] internal CustomButton SignOutButton { get; private set; }
        [field: SerializeField] internal CustomButton CloseButton { get; private set; }
    }
}