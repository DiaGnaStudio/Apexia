using Unit.Data;
using UnityEngine;

namespace Unit.Logic.Assets
{
    [CreateAssetMenu(fileName = "UnitMaterialRepo", menuName = "Unit/MaterialRepo")]
    internal class UnitMaterialRepo : ScriptableObject
    {
        [SerializeField] private Data[] mapDatas;

        public static UnitMaterialRepo PreLoad =>
            Resources.Load<UnitMaterialRepo>(typeof(UnitMaterialRepo).Name);

        public Material GetSelect(Availabilty availabilty)
        {
            foreach (var data in mapDatas)
                if (data.availabilty == availabilty)
                    return data.select;

            throw new System.NullReferenceException();
        }

        public Material GetUnselect(Availabilty availabilty)
        {
            foreach (var data in mapDatas)
                if (data.availabilty == availabilty)
                    return data.unselect;

            throw new System.NullReferenceException();
        }

        public Material GetBody(Availabilty availabilty)
        {
            foreach (var data in mapDatas)
                if (data.availabilty == availabilty)
                    return data.body;

            throw new System.NullReferenceException();
        }

        [System.Serializable]
        private struct Data
        {
            public Availabilty availabilty;
            public Material select;
            public Material unselect;
            public Material body;
        }
    }
}
