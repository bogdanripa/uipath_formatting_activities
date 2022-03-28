using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UiPathTeam.BasicTypes.Activities
{
    [ExcludeFromCodeCoverage]
    public class GetTimeBetweenDatesActivity : CodeActivity
    {
        public InArgument<DateTime> StartDate { get; set; }
        public InArgument<DateTime> EndDate { get; set; }
        public InArgument<string> Unit { get; set; }
        public OutArgument<int> Time { get; set; }
        public OutArgument<TimeSpan> Interval { get; set; }

        protected static int GetBusinessDays(DateTime start, DateTime end)
        {
            if (start.DayOfWeek == DayOfWeek.Saturday)
            {
                start = start.AddDays(2);
            }
            else if (start.DayOfWeek == DayOfWeek.Sunday)
            {
                start = start.AddDays(1);
            }

            if (end.DayOfWeek == DayOfWeek.Saturday)
            {
                end = end.AddDays(-1);
            }
            else if (end.DayOfWeek == DayOfWeek.Sunday)
            {
                end = end.AddDays(-2);
            }

            int diff = (int)end.Subtract(start).TotalDays;

            int result = diff / 7 * 5 + diff % 7;

            if (end.DayOfWeek < start.DayOfWeek)
            {
                return result - 2;
            }
            else
            {
                return result;
            }
        }


        protected override void Execute(CodeActivityContext context)
        {
            if (StartDate.Get(context) == DateTime.MinValue)
            {
                throw new Exception("The Start Date was not provided");
            }
            if (EndDate.Get(context) == DateTime.MinValue)
            {
                throw new Exception("The End Date was not provided");
            }

            switch (Unit.Get(context))
            {
                case "Seconds":
                    Time.Set(context, Convert.ToInt32((EndDate.Get(context) - StartDate.Get(context)).TotalSeconds));
                    break;
                case "Minutes":
                    Time.Set(context, Convert.ToInt32((EndDate.Get(context) - StartDate.Get(context)).TotalMinutes));
                    break;
                case "Hours":
                    Time.Set(context, Convert.ToInt32((EndDate.Get(context) - StartDate.Get(context)).TotalHours));
                    break;
                case "Days":
                    Time.Set(context, Convert.ToInt32((EndDate.Get(context) - StartDate.Get(context)).TotalDays));
                    break;
                case "Business days":
                    Time.Set(context, GetBusinessDays(StartDate.Get(context), EndDate.Get(context)));
                    break;
                case "Interval":
                    Interval.Set(context, EndDate.Get(context) - StartDate.Get(context));
                    break;
            }
        }
    }
}
