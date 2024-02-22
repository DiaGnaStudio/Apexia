using TMPro;
using UnityEngine;

namespace CustomInfo.View
{
    public class CustomerInfoView : MonoBehaviour
    {
        [field: SerializeField] internal TMP_Text PresenterNameTxt { get; private set; }
        [field: SerializeField] internal TMP_Text CustomerNameTxt { get; private set; }
    }
}