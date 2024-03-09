using UnityEngine;
using UnityEngine.UI;

namespace SidePanel.View.Components
{
    [RequireComponent(typeof(Animator))]
    internal class CustomAnimation : MonoBehaviour
    {
        private Animator _animator;
        [SerializeField] private Button _changeStateBtn;
        [SerializeField] private string parameter = "Show";

        [SerializeField] private bool initialState;
        private bool currentState;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            currentState = initialState;

            _changeStateBtn.onClick.AddListener(ChangeState);

            void ChangeState()
            {
                _animator.SetBool(parameter, !currentState);
            }
        }

        public void ForceHide() =>
            _animator.SetBool(parameter, initialState);
    }
}