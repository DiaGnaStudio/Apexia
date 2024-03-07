using Order.Provider;
using System;
using UnityEngine;

namespace CustomerInfo.Core.Module
{
    internal class OrderSender
    {
        private Action OnSuccess;
        private Action OnFailure;

        private int sendedIndex = 0;

        public void Initialize(Action onSuccess, Action onFailure)
        {
            OnSuccess = onSuccess;
            OnFailure = onFailure;
        }

        public void Send(int[] unitIds, int clientId)
        {
            sendedIndex = 0;
            foreach (var id in unitIds)
                Send(id, clientId, SendSuccessfuly);

            void Send(int unitId, int clientId, Action onSuccess)
            {
                OrderService.Send(unitId, clientId, Get, Error);

                void Get() =>
                    onSuccess.Invoke();

                void Error(string message)
                {
                    OnFailure.Invoke();
                    Debug.LogError(message);
                }
            }

            void SendSuccessfuly()
            {
                if (++sendedIndex == unitIds.Length)
                    OnSuccess.Invoke();
            }
        }
    }
}