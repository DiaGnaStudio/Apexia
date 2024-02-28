using System.Text;

namespace UnitPayment.Provider
{
    public class UnitPaymentData
    {
        public Info info;
        public Downpayment[] downpayments;
        public Installment[] installments;
        public OtherFee[] otherFees;
        public Downpayment[] surpluspayments;
        public Duration duration;

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine("Info:");
            sb.AppendLine(info.ToString());

            sb.AppendLine("Downpayments:");
            foreach (var downpayment in downpayments)
            {
                sb.AppendLine(downpayment.ToString());
            }

            sb.AppendLine("Installments:");
            foreach (var installment in installments)
            {
                sb.AppendLine(installment.ToString());
            }

            sb.AppendLine("Other Fees:");
            foreach (var otherFee in otherFees)
            {
                sb.AppendLine(otherFee.ToString());
            }

            sb.AppendLine("Surplus Payments:");
            foreach (var surpluspayment in surpluspayments)
            {
                sb.AppendLine(surpluspayment.ToString());
            }

            sb.AppendLine("Duration:");
            sb.AppendLine(duration.ToString());

            return sb.ToString();
        }

        public class Info
        {
            public string name;
            public bool active;
            public int price;
            public object roi;
            public Unit unit;
            public string settlement_type;

            public override string ToString()
            {
                return $"Name: {name}, Active: {active}, Price: {price}, Settlement Type: {settlement_type}, Unit: {unit}";
            }

            public class Unit
            {
                public int id;
                public string name;
                public string status;
                public string area;
                public int floor;
                public string unit_type;
                public object direction;

                public override string ToString()
                {
                    return $"ID: {id}, Name: {name}, Status: {status}, Area: {area}, Floor: {floor}, Unit Type: {unit_type}, Direction: {direction}";
                }
            }
        }

        public class Downpayment
        {
            public string title;
            public int percent;
            public int fee;
            public string dateInLetter;
            public string realDate;
            public object type;

            public override string ToString()
            {
                return $"Title: {title}, Percent: {percent}, Fee: {fee}, Date In Letter: {dateInLetter}, Real Date: {realDate}, Type: {type}";
            }
        }

        public class Installment
        {
            public string title;
            public float percent;
            public int fee;
            public string dateInLetter;
            public string realDate;
            public object type;

            public override string ToString()
            {
                return $"Title: {title}, Percent: {percent}, Fee: {fee}, Date In Letter: {dateInLetter}, Real Date: {realDate}, Type: {type}";
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
                return $"Title: {title}, Percent: {percent}, Fee: {fee}, Date In Letter: {dateInLetter}, Real Date: {realDate}, Type: {type}";
            }
        }

        public class Duration
        {
            public Date first;
            public Date last;
            public int diff;

            public override string ToString()
            {
                return $"First Date: {first}, Last Date: {last}, Difference: {diff}";
            }
        }

        public class Date
        {
            public string dateInLetter;
            public string realDate;

            public override string ToString()
            {
                return $"Date In Letter: {dateInLetter}, Real Date: {realDate}";
            }
        }
    }

}