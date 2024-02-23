using UnityEngine;
using UnityEngine.UI;

namespace SidePanel.View.Components
{
    [RequireComponent(typeof(Animator))]
    internal class CustomAnimation : MonoBehaviour
    {
        private const string SHOW_PARAMETER = "Show";

        private Animator _animator;
        [SerializeField] private Button _changeStateBtn;

        private void Awake()
        {
            _animator = GetComponent<Animator>();

            _changeStateBtn.onClick.AddListener(ChangeState);

            void ChangeState()
            {
                bool currentValue = _animator.GetBool(SHOW_PARAMETER);
                _animator.SetBool(SHOW_PARAMETER, !currentValue);
            }
        }

        public void ForceHide() =>
            _animator.SetBool(SHOW_PARAMETER, false);
    }
}