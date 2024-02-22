using System;
using UCamSystem;
using Unit.SharedTypes;
using UnityEngine;

namespace Unit.Logic.Components
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(Collider))]
    internal class Unit : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private UCamPoint ballconyCamPoint;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Collider collicer;

        [Header("Materials")]
        [SerializeField] private Material matHighlight;
        [SerializeField] private Material matSelect;
        [SerializeField] private Material matUnselect;

        private const float DOUBLE_TAP_TIME = .6f;
        private float firstTapTime;

        private bool isShow = false;

        [field: SerializeField] public UnitCard Card { get; private set; }

        private Action<UnitCard> OnSelect;

        public void Awake()
        {
            meshRenderer ??= GetComponent<MeshRenderer>();
            collicer ??= GetComponent<BoxCollider>();
        }

        public void SetSelectAction(Action<UnitCard> action) =>
            OnSelect = action;

        public void GoToBalcony() =>
            ballconyCamPoint.Set();

        private void OnMouseDown()
        {
            if (isShow) return;

            if (firstTapTime + DOUBLE_TAP_TIME > Time.time)
                Select();
            else
                firstTapTime = Time.time;

            void Select()
            {
                OnSelect?.Invoke(Card);
                isShow = true;
                SetMaterial(matSelect);
            }
        }

        public void UnSelect()
        {
            if (!isShow) return;

            isShow = false;
        }

        public void Highlight(bool value)
        {
            if (value)
            {
                SetMaterial(matHighlight);
                collicer.enabled = true;
            }
            else
            {
                SetMaterial(matUnselect);
                collicer.enabled = false;
            }
        }

        private void SetMaterial(Material mat) =>
            meshRenderer.material = mat;
    }
}