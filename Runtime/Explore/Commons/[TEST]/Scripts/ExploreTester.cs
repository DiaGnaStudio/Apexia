using UnityEngine;

namespace Explore.Test
{
    public class ExploreTester : MonoBehaviour
    {
        [ContextMenu("Show")]
        private void Show() => ExploreSystem.Show();
    }
}