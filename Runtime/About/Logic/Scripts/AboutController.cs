using About.Assets;
using UnityEngine;

namespace About.Logic
{
    [CreateAssetMenu(fileName = "AboutController", menuName = "About/Controller", order = 0)]

    public class AboutController : ScriptableObject
    {
        public static AboutController LoadInstance =>
            Resources.Load<AboutController>(typeof(AboutController).Name);

        [field: SerializeField] public AboutAsset[] Assets { get; private set; }
    }
}