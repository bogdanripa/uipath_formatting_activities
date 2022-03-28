using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPathTeam.BasicTypes.Activities
{
    [ExcludeFromCodeCoverage]
    public class AdjustDateActivity : CodeActivity
    {
        public InArgument<DateTime> InputDate { get; set; }
        public InArgument<string> AdjustMethod { get; set; }
        public InArgument<string> Units { get; set; }
        public InArgument<int> Value { get; set; }
        public OutArgument<DateTime> AdjustedDate { get; set; }

        protected static DateTime AddBusinessDays(DateTime source, int businessDays)
        {
            var dayOfWeek = businessDays < 0
                                ? ((int)source.DayOfWeek - 12) % 7
                                : ((int)source.DayOfWeek + 6) % 7;

            switch (dayOfWeek)
            {
                case 6:
                    businessDays--;
                    break;
                case -6:
                    businessDays++;
                    break;
            }

            return source.AddDays(businessDays + ((businessDays + dayOfWeek) / 5) * 2);
        }

        protected override void Execute(CodeActivityContext context)
        {
            DateTime d = InputDate.Get(context);
            int direction = 1;
            if (AdjustMethod.Get(context) == "Substract")
                direction = -1;

            switch (AdjustMethod.Get(context))
            {
                case "Substract":
                case "Add":
                    switch(Units.Get(context))
                    {
                        case "Seconds":
                            AdjustedDate.Set(context, d.AddSeconds(direction * Value.Get(context)));
                            break;
                        case "Minutes":
                            AdjustedDate.Set(context, d.AddMinutes(direction * Value.Get(context)));
                            break;
                        case "Hours":
                            AdjustedDate.Set(context, d.AddHours(direction * Value.Get(context)));
                            break;
                        case "Days":
                            AdjustedDate.Set(context, d.AddDays(direction * Value.Get(context)));
                            break;
                        case "Business days":
                            AdjustedDate.Set(context, AddBusinessDays(d, direction * Value.Get(context)));
                            break;
                        case "Weeks":
                            AdjustedDate.Set(context, d.AddDays(7 * direction * Value.Get(context)));
                            break;
                        case "Months":
                            AdjustedDate.Set(context, d.AddMonths(direction * Value.Get(context)));
                            break;
                        case "Years":
                            AdjustedDate.Set(context, d.AddYears(direction * Value.Get(context)));
                            break;
                    }
                    break;
                case "Start of day":
                    AdjustedDate.Set(context, d.Date);
                    break;
                case "Start of week":
                    AdjustedDate.Set(context, d.Date.AddDays(-(int)d.DayOfWeek));
                    break;
                case "Start of month":
                    AdjustedDate.Set(context, d.Date.AddDays(1 - d.Day));
                    break;
                case "Start of year":
                    AdjustedDate.Set(context, d.AddDays(1 - d.DayOfYear));
                    break;
            }
        }
    }
}
