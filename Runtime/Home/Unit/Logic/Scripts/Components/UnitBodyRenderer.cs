using Unit.Data;
using Unit.Logic.Assets;
using UnityEngine;

namespace Unit.Logic.Components
{
    [RequireComponent(typeof(MeshRenderer))]
    internal class UnitBodyRenderer : MonoBehaviour
    {
        [SerializeField] private UnitMaterialRepo materialRepo;

        private MeshRenderer meshRenderer;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        public void Apply(Availabilty availabilty) =>
            meshRenderer.material = materialRepo.GetBody(availabilty);
    }
}