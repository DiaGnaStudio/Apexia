using UCamSystem;
using UnityEngine;

namespace Unit.Logic
{
    [CreateAssetMenu(fileName = "UnitCamera", menuName = "Unit/Camera")]
    internal class UnitCamera : ScriptableObject
    {
        [SerializeField] private UCamPoint camPointPrefab;

        private UCamPoint camPoint;

        public static UnitCamera LoadInstance =>
            Resources.Load<UnitCamera>(typeof(UnitCamera).Name);

        public void Initialize() =>
            camPoint = Instantiate(camPointPrefab);

        public void SetPoints() =>
            camPoint.Set();
    }
}