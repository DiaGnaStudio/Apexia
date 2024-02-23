using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amenities.Test
{
    public class AmenitiesTester : MonoBehaviour
    {
        [ContextMenu("Show")]
        private void Show() => AmenitiesSystem.Show();

        [ContextMenu("Hide")]
        private void Hide() => AmenitiesSystem.Hide();
    }
}