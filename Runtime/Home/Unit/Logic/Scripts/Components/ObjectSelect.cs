using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unit.Logic.Components
{
    [RequireComponent(typeof(Collider))]
    internal class ObjectSelect : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        private Action OnClick;

        public void SetSlick(Action onClick) =>
            OnClick = onClick;

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
                OnClick.Invoke();
        }

        public void SetColliderAction(bool value) =>
            _collider.enabled = value;
    }
}