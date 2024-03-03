namespace Unit.Data
{
    public struct UnitInstallmentsData
    {
        public UnitInstallmentsData(Info unitInfo, Payment[] payments, AditionalFee[] aditionalFees)
        {
            UnitInfo = unitInfo;
            Payments = payments;
            AditionalFees = aditionalFees;
        }

        public Info UnitInfo { get; private set; }
        public Payment[] Payments { get; private set; }
        public AditionalFee[] AditionalFees { get; private set; }

        public static UnitInstallmentsData Empty => new();

        public struct Info
        {
            public Info(string name, int price, int duration, string type, string area)
            {
                Name = name;
                Price = price;
                Duration = duration;
                Type = type;
                Area = area;
            }

            public string Name { get; private set; }
            public int Price {  get; private set; }
            public int Duration { get; private set; }
            public string Type { get; private set; }
            public string Area { get; private set; }
        }

        public struct Payment
        {
            private readonly string title;
            private readonly float percent;

            public Payment(string title, float percent, string dateInLetter, int fee)
            {
                this.title = title;
                this.percent = percent;
                DateInLetter = dateInLetter;
                Fee = fee;
            }

            public string DateInLetter { get; private set; }
            public int Fee { get; private set; }
            public readonly string Title =>
                percent > 0 ? string.Format("{0} ({1}%)", title, percent) : title;
        }

        public struct AditionalFee
        {
            private readonly string title;
            private readonly float percent;

            public AditionalFee(string title, float percent, int fee)
            {
                this.title = title;
                this.percent = percent;
                Fee = fee;
            }

            public int Fee { get; private set; }
            public readonly string Title =>
                percent > 0 ? string.Format("{0} ({1}%)", title, percent) : title;
        }
    }
}