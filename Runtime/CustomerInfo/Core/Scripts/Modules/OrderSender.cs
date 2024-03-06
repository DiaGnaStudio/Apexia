using Order.Provider;
using System;
using UnityEngine;

namespace CustomerInfo.Core.Module
{
    internal class OrderSender
    {
        private readonly Action OnSuccess;
        private readonly Action OnFailure;

        public OrderSender(Action onSuccess, Action onFailure)
        {
            OnSuccess = onSuccess;
            OnFailure = onFailure;
        }

        public void Send(int[] unitId, int clientId)
        {
            OrderService.Send(unitId, clientId, Get, Error);

            void Get() =>
                OnSuccess.Invoke();

            void Error(string message)
            {
                OnFailure.Invoke();
                Debug.LogError(message);
            }
        }
    }
}