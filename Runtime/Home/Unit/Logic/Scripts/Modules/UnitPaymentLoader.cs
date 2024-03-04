using System;
using Unit.Data;
using UnitPayment.Provider;
using UnityEngine;
using static Unit.Data.UnitInstallmentsData;

namespace Unit.Logic.Module
{
    internal class UnitPaymentLoader
    {
        public void Load(int id, Action<UnitInstallmentsData> onLoad)
        {
            UnitPaymentService.GetById(id, Get, Error);

            void Get(UnitPaymentData data)
            {
                Info info = new(data.info.unit.name, data.info.price, data.duration.diff, data.info.unit.unit_type, data.info.unit.area);
                Payment[] payments = GetPayments(data);
                AditionalFee[] aditionalFees = GetAdutuonalFees(data);
                onLoad.Invoke(new(info, payments, aditionalFees));

                static Payment[] GetPayments(UnitPaymentData data)
                {
                    Payment[] payments = new Payment[data.downpayments.Length + data.installments.Length];
                    int index = 0;
                    for (int i = 0; i < data.downpayments.Length; index++, i++)
                    {
                        var downpayment = data.downpayments[i];
                        payments[index] = new Payment(downpayment.title, downpayment.percent, downpayment.dateInLetter, downpayment.fee);
                    }
                    for (int i = 0; i < data.installments.Length; index++, i++)
                    {
                        var installment = data.installments[i];
                        payments[index] = new Payment(installment.title, installment.percent, installment.dateInLetter, installment.fee);
                    }

                    return payments;
                }

                static AditionalFee[] GetAdutuonalFees(UnitPaymentData data)
                {
                    AditionalFee[] aditionalFees = new AditionalFee[data.otherFees.Length + data.surpluspayments.Length];
                    int index = 0;
                    for (int i = 0; i < data.otherFees.Length; index++, i++)
                    {
                        var otherFee = data.otherFees[i];
                        aditionalFees[index] = new AditionalFee(otherFee.title, otherFee.percent, otherFee.fee);
                    }
                    for (int i = 0; i < data.surpluspayments.Length; index++, i++)
                    {
                        var surpluspayment = data.surpluspayments[i];
                        aditionalFees[index] = new AditionalFee(surpluspayment.title, surpluspayment.percent, surpluspayment.fee);
                    }

                    return aditionalFees;
                }
            }

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}