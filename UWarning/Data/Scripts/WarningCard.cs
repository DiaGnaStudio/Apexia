using UnityEngine;

namespace UWarning.Data
{
    [CreateAssetMenu(fileName = "WarningCard", menuName = "Warning/Card")]
    public class WarningCard : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField,Multiline] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public ButtonInfo AccecptButton { get; private set; } = new("Try Again");
        [field: SerializeField] public ButtonInfo RejectButton { get; private set; } = new("Back");

        [System.Serializable]
        public struct ButtonInfo
        {
            public bool isActive;
            public string text;

            public ButtonInfo(string text)
            {
                isActive = true;
                this.text = text;
            }
        }
    }
}
