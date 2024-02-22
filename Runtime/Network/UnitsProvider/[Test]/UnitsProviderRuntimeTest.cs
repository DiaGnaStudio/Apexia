using System.Linq;
using Units.Provider.Data;
using UnityEngine;

namespace Units.Provider.Test
{
    public class UnitPaymentProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private int id;

        [ContextMenu("GetById")]
        private void GetById()
        {
            UnitServices.GetById(id, Load, Error);

            void Load(UnitData data) =>
                Debug.Log(data.ToString());

            void Error(string message) =>
                Debug.LogError(message);
        }

        [ContextMenu("GetAll")]
        private void GetAll()
        {
            UnitServices.GetAll(Load, Error);

            void Load(UnitData[] data) =>
                Debug.Log(string.Join("\n", data.Select(item => $"{{\n{item}\n}}")));

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}