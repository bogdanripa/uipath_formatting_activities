using System;
using System.Activities;
using System.Activities.DesignViewModels;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPathTeam.BasicTypes.Resources;

namespace UiPathTeam.BasicTypes.ViewModel
{
    /// <summary>
    /// This is the view model for an activity that controls the visibility of properties based on another property.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class GetTimeBetweenDatesActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<DateTime> StartDate { get; set; }
        public DesignInArgument<DateTime> EndDate { get; set; }
        public DesignInArgument<string> Unit { get; set; }
        public DesignOutArgument<int> Time { get; set; }
        public DesignOutArgument<TimeSpan> Interval { get; set; }

        private DataSource<string> _unitDataSource;
        public GetTimeBetweenDatesActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            StartDate.IsPrincipal = true;
            StartDate.IsRequired = true;
            StartDate.DisplayName = Resource1.GetTimeBetweenDatesActivity_Property_StartDate;

            EndDate.IsPrincipal = true;
            EndDate.IsRequired = true;
            EndDate.DisplayName = Resource1.GetTimeBetweenDatesActivity_Property_EndDate;

            Unit.IsPrincipal = true;
            Unit.IsRequired = true;
            Unit.DisplayName = Resource1.GetTimeBetweenDatesActivity_Property_Unit;

            Time.IsPrincipal = false;
            Time.DisplayName = Resource1.GetTimeBetweenDatesActivity_Property_Time;

            Interval.IsPrincipal = false;
            Time.DisplayName = Resource1.GetTimeBetweenDatesActivity_Property_Interval;

            // data source for the dropdown
            _unitDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            Unit.DataSource = _unitDataSource;

            Unit.Widget = new DefaultWidget() { Type = "Dropdown" };

            //dropdown values
            _unitDataSource.Data = new string[6] { "Seconds", "Minutes", "Hours", "Days", "Business days", "Interval" };
            if (Unit.Value is null)
            {
                Unit.Value = "Hours";
            }
            Time.DisplayName = Resource1.GetTimeBetweenDatesActivity_Property_Time + " (" + GetStringValue(Unit.Value) + ")";

            if (GetStringValue(Unit.Value) == "Interval")
            {
                Interval.IsVisible = true;
                Time.IsVisible = false;
            } else {
                Interval.IsVisible = false;
                Time.IsVisible = true;
            }
        }

        protected override void InitializeRules()
        {
            base.InitializeRules();
            Rule("Unit", () =>
            {
                Time.DisplayName = Resource1.GetTimeBetweenDatesActivity_Property_Time + " (" + GetStringValue(Unit.Value) + ")";
                if (GetStringValue(Unit.Value) == "Interval")
                {
                    Interval.IsVisible = true;
                    Time.IsVisible = false;
                }
                else
                {
                    Interval.IsVisible = false;
                    Time.IsVisible = true;
                }
            });
        }

        private static string GetStringValue(object objectToConvert)
        {
            string result = null;
            if (objectToConvert is InArgument<string> arg)
            {
                var value = arg.Expression.ToString();

                if (!string.IsNullOrEmpty(value))
                {
                    result = value;
                }
            }
            return result;
        }
    }
}
