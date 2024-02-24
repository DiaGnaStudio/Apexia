using System.Linq;
using UnityEngine;

namespace Unit.Logic.Assets
{
    [CreateAssetMenu(fileName = "UnitMapRepo", menuName = "Unit/MapRepo")]
    internal class UnitMapRepo : ScriptableObject
    {
        [SerializeField] private Data[] mapDatas;

        public static UnitMapRepo PreLoad =>
            Resources.Load<UnitMapRepo>(typeof(UnitMapRepo).Name);

        public Sprite Get(int code, int floor)
        {
            foreach (var data in mapDatas)
                if (data.code == code && data.floors.Any(x => x == floor))
                    return data.map;

            throw new System.NullReferenceException($"The map is not available (code = {code} and floor = {floor})");
        }

        [System.Serializable]
        private struct Data
        {
            public Sprite map;
            [Range(1, 13)] public int[] floors;
            public int code;
        }
    }
}
