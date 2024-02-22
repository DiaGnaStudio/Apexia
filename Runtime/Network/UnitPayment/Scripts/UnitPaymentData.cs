using System.Collections.Generic;

namespace UnitPayment.Provider
{
    public class UnitPaymentData
    {
        public Info info;
        public List<Downpayment> downpayments;
        public List<Installment> installments;
        public List<OtherFee> otherFees;
        public List<SurplusPayments> surplusPayments;

        public class Info
        {
            public string name;
            public bool active;
            public int price;
            public object roi; // It's null in the provided JSON
            public string settlementType;

            public override string ToString()
            {
                return $"Info:\n" +
                       $"Name: {name}\n" +
                       $"Active: {active}\n" +
                       $"Price: {price}\n" +
                       $"ROI: {roi}\n" +
                       $"Settlement Type: {settlementType}\n";
            }
        }

        public class Downpayment
        {
            public string title;
            public int percent;
            public int fee;
            public string dateInLetter;
            public string realDate;
            public object type; // It's null in the provided JSON

            public override string ToString()
            {
                return $"Downpayment:\n" +
                       $"Title: {title}\n" +
                       $"Percent: {percent}\n" +
                       $"Fee: {fee}\n" +
                       $"Date in Letter: {dateInLetter}\n" +
                       $"Real Date: {realDate}\n";
            }
        }

        public class Installment
        {
            public string title;
            public double percent;
            public double fee;
            public string dateInLetter;
            public string realDate;
            public object type; // It's null in the provided JSON

            public override string ToString()
            {
                return $"Installment:\n" +
                       $"Title: {title}\n" +
                       $"Percent: {percent}\n" +
                       $"Fee: {fee}\n" +
                       $"Date in Letter: {dateInLetter}\n" +
                       $"Real Date: {realDate}\n";
            }
        }

        public class OtherFee
        {
            public string title;
            public int percent;
            public int fee;
            public string dateInLetter;
            public string realDate;
            public string type;

            public override string ToString()
            {
                return $"Other Fee:\n" +
                       $"Title: {title}\n" +
                       $"Percent: {percent}\n" +
                       $"Fee: {fee}\n" +
                       $"Date in Letter: {dateInLetter}\n" +
                       $"Real Date: {realDate}\n" +
                       $"Type: {type}\n";
            }
        }

        public class SurplusPayments
        {

        }

        public override string ToString()
        {
            string result = info.ToString();
            result += "Downpayments:\n";
            foreach (var downpayment in downpayments)
            {
                result += downpayment.ToString();
            }
            result += "Installments:\n";
            foreach (var installment in installments)
            {
                result += installment.ToString();
            }
            result += "Other Fees:\n";
            foreach (var otherFee in otherFees)
            {
                result += otherFee.ToString();
            }
            return result;
        }
    }

}