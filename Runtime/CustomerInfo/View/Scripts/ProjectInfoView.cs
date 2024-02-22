using TMPro;
using UnityEngine;

namespace ProjectInfo.View
{
    public class ProjectInfoView : MonoBehaviour
    {
        [field: SerializeField] internal TMP_Text PresenterNameTxt { get; private set; }
        [field: SerializeField] internal TMP_Text CustomerNameTxt { get; private set; }
    }
}