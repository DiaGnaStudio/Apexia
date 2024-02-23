using Gallery.View.Components;
using UnityEngine;
using UScreens;

namespace Gallery.View
{
    public class GalleryView : UPanel
    {
        [field: SerializeField] internal PreviewPanel PreviewPanel { get; private set; }
        [field: SerializeField] internal GalleryButton GalleryButton { get; private set; }
        [field: SerializeField] internal ScrollPanel ScrollPanel { get; private set; }
    }
}