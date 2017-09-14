using HotDocs.Constants;
using HotDocs.Enums;
using System;
using System.Globalization;

namespace HotDocs
{
    public class StayDuration
    {
        public StayDuration(StayType Type, DateTime Start, DateTime End)
        {
            this.Start = Start;
            this.Type = Type;
            this.End = End;
            CalculateStayPrice();
        }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public StayType Type { get; set; }
        public Double Fee { get; set; }

        private void CalculateStayPrice()
        {
            switch (Type)
            {
                case StayType.ShortStay:
                    Fee = CalculateBillableHours() * Prices.HourlyRate;
                    break;
                case StayType.LongStay:
                    Fee = CalculateDays() * Prices.DailyRate;
                    break;
                default:
                    break;
            }
        }

        private int CalculateDays()
        {
            if (End == Start) return 0;

            //add first day
            return 1 + (End.DayOfYear - Start.DayOfYear);
        }

        private int CalculateBillableHours()
        {
            var billable = 0;

            var tempDate = Start;

            while (End > tempDate)
            {
                if (tempDate.Hour >= 8 && tempDate.Hour < 18 && tempDate.DayOfWeek != DayOfWeek.Saturday && tempDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    billable++;
                }
                tempDate = tempDate.AddHours(1);
            }

            return billable;
        }

        public void PrintResult()
        {
            Console.WriteLine($"{Type} from {Start.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)} to {End.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)} = {Fee:c}");
        }
    }
}
