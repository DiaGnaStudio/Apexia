using UnityEngine;

namespace ProjectInfo.Test
{
    public class ProjectInfoTest : MonoBehaviour
    {
        [SerializeField] private string presenter;
        [SerializeField] private string customer;

        private void Awake()
        {
            Show();
        }

        [ContextMenu("Show")]
        private void Show()
        {
            ProjectInfoSystem.SetPresenter(() => presenter);
            ProjectInfoSystem.SetCustomer(() => customer);
            ProjectInfoSystem.Show();
        }
    }
}