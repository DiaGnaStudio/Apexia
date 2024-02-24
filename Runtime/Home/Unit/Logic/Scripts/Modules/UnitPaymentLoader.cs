using System;
using Unit.Data;
using UnitPayment.Provider;
using UnityEngine;

namespace Unit.Logic.Module
{
    internal class UnitPaymentLoader
    {
        public void Load(string id, Action<(string, UnitInstallmentsData)> onLoad)
        {
            UnitPaymentService.GetById(id, Get, Error);

            void Get(UnitPaymentData data)
            {
                UnitInstallmentsData installmentsData = new();
                onLoad.Invoke((id, installmentsData));
            }

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}