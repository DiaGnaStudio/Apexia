using Unit.Data;
using Unit.Logic.Assets;
using UnityEngine;

namespace Unit.Logic.Components
{
    [RequireComponent(typeof(MeshRenderer))]
    internal class UnitBorderRenderer : MonoBehaviour
    {
        [SerializeField] private UnitMaterialRepo materialRepo;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void Apply(Availabilty availabilty, bool select) =>
            meshRenderer.material = select ? GetSelect(availabilty) : GetUnselect(availabilty);

        private Material GetSelect(Availabilty availabilty) =>
            materialRepo.GetSelect(availabilty);

        private Material GetUnselect(Availabilty availabilty) =>
            materialRepo.GetUnselect(availabilty);

        public void SetActive(bool value) =>
            meshRenderer.enabled = value;
    }
}