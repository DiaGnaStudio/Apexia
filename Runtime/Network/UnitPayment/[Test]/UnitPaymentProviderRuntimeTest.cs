using UHTTP;
using UnityEngine;

namespace UnitPayment.Provider.Test
{
    public class UnitPaymentProviderRuntimeTest : MonoBehaviour
    {
        [SerializeField] private string id;

        [ContextMenu("GetById")]
        private void GetById()
        {
            UnitPaymentService.GetById(id, Load, Error);

            void Load(UnitPaymentData data) =>
                Debug.Log(data.ToString());

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}