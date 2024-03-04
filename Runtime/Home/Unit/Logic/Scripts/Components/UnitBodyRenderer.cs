using Unit.Data;
using Unit.Logic.Assets;
using UnityEngine;

namespace Unit.Logic.Components
{
    [RequireComponent(typeof(MeshRenderer))]
    internal class UnitBodyRenderer : MonoBehaviour
    {
        [SerializeField] private UnitMaterialRepo materialRepo;

        [SerializeField] private MeshRenderer meshRenderer;

        public void Apply(Availabilty availabilty) =>
            meshRenderer.material = materialRepo.GetBody(availabilty);

        public void SetActive(bool value) => 
            meshRenderer.enabled = value;
    }
}