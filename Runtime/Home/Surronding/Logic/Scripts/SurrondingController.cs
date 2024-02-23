using Surronding.Logic.Components;
using UCamSystem;
using UnityEngine;

namespace Surronding.Logic
{
    [CreateAssetMenu(fileName = "SurrondingController", menuName = "Surronding/Controller", order = 0)]
    public class SurrondingController : ScriptableObject
    {
        public static SurrondingController LoadInstance =>
            Resources.Load<SurrondingController>(typeof(SurrondingController).Name);

        [SerializeField] private UPointList camPointPrefab;

        public UPointList CamPoint { get; private set; }
        public SurrondingFilterController FilterController { get; private set; }

        public void Initialize()
        {
            CamPoint = Instantiate(camPointPrefab);

            var enviroment = FindObjectOfType<SurrondingEnviroment>();
            FilterController = new SurrondingFilterController(enviroment.ApplyFilter);
        }

        public string[] GetItemsName() =>
            CamPoint.ItemsName;

        public void Select(int index) =>
            CamPoint.Select(index);
    }
}