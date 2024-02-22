using UnityEngine;

namespace UCamSystem
{
    public class UPointList : MonoBehaviour
    {
        [SerializeField] private UCamPoint[] Items;

        public string[] ItemsName
        {
            get
            {
                string[] items = new string[Items.Length];
                for (int i = 0; i < Items.Length; i++)
                    items[i] = Items[i].name;

                return items;
            }
        }

        public void Select(int index)
        {
            if (Items.Length > index && index > -1)
                Items[index].Set();
        }
    }
}