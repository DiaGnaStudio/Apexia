using Surronding.Logic.SharedTypes;
using Surronding.SharedTypes;
using System.Collections.Generic;
using UnityEngine;

namespace Surronding.Logic.Components
{
    internal class SurrondingEnviroment : MonoBehaviour
    {
        [SerializeField] private SurrondingLevel[] items;

        private readonly List<GameObject> allObjects = new();

        private void Awake()
        {
            foreach (var item in items)
                foreach (var obj in item.objects)
                    allObjects.Add(obj.target);
        }

        public void ApplyFilter(SurrendingFilter filter)
        {
            foreach (var unit in allObjects)
                unit.SetActive(false);

            foreach (var item in items)
            {
                if (!filter.IsDistanceCountins(item.distance)) continue;

                foreach (var obj in item.objects)
                {
                    if (!filter.IsMapGuideCountins(obj.type)) continue;

                    obj.target.SetActive(true);
                }
            }
        }
    }
}

namespace Surronding.Logic.SharedTypes
{
    [System.Serializable]
    internal class SurrondingLevel
    {
        public WalkingDistanceType distance;
        public Item[] objects;

        [System.Serializable]
        public struct Item
        {
            public MapGuideType type;
            public GameObject target;
        }
    }
}