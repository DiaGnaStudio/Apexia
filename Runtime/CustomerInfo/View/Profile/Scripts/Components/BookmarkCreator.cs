using CustomerInfo.Data;
using UnityEngine;
using UPatterns;

namespace CustomerInfo.View.Profile.Components
{
    public class BookmarkCreator : MonoBehaviour
    {
        [SerializeField] private Pool<UnitInfoSlot> itemPool;

        public void SetDatas(OrderInfo[] infos)
        {
            itemPool.DeactiveAllInstance();

            foreach (var info in infos)
                itemPool.GetActive.SetData(info);
        }

        public void DisableAll()
        {
            itemPool.DeactiveAllInstance();
        }
    }
}
