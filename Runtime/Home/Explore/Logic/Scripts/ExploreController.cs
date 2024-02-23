using UCamSystem;
using UnityEngine;

namespace Explore.Logic
{
    [CreateAssetMenu(fileName = "ExploreController", menuName = "Explore/Controller")]
    public class ExploreController : ScriptableObject
    {
        [SerializeField] private UCamPoint camPointPrefab;

        private UCamPoint camPoint;

        public static ExploreController LoadInstance =>
            Resources.Load<ExploreController>(typeof(ExploreController).Name);

        public void Initialize() => 
            camPoint = Instantiate(camPointPrefab);

        public void SetPoints() =>
            camPoint.Set();
    }
}