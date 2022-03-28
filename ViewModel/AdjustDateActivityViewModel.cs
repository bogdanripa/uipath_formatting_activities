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
    public partial class AdjustDateActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<DateTime> InputDate { get; set; }
        public DesignInArgument<string> AdjustMethod { get; set; }
        public DesignInArgument<string> Units { get; set; }
        public DesignInArgument<int> Value { get; set; }
        public DesignOutArgument<DateTime> AdjustedDate{ get; set; }

        private DataSource<string> _adjustDataSource;
        private DataSource<string> _unitsDataSource;
        public AdjustDateActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputDate.IsPrincipal = true;
            InputDate.IsRequired = true;
            InputDate.DisplayName = Resource1.AdjustDateActivity_Property_InputDate;

            AdjustMethod.IsPrincipal = true;
            AdjustMethod.IsRequired = true;
            AdjustMethod.DisplayName = Resource1.AdjustDateActivity_Property_AdjustMethod;

            Value.IsPrincipal = true;
            Value.IsVisible = false;
            Value.DisplayName = Resource1.AdjustDateActivity_Property_Value;

            Units.IsPrincipal = true;
            Units.IsVisible = false;
            Units.DisplayName = Resource1.AdjustDateActivity_Property_Unit;

            AdjustedDate.IsPrincipal = false;
            AdjustedDate.IsVisible = true;
            AdjustedDate.DisplayName = Resource1.AdjustDateActivity_Property_AdjustedDate;

            // data source for the dropdown
            _adjustDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            AdjustMethod.DataSource = _adjustDataSource;

            // data source for the dropdown
            _unitsDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            Units.DataSource = _unitsDataSource;

            AdjustMethod.Widget = new DefaultWidget() { Type = "Dropdown" };
            Units.Widget = new DefaultWidget() { Type = "Dropdown" };

            //dropdown values
            _adjustDataSource.Data = new string[6] { "Add", "Substract", "Start of day", "Start of week", "Start of month", "Start of year" };
            _unitsDataSource.Data = new string[8] { "Seconds", "Minutes", "Hours", "Days", "Business days", "Weeks", "Months", "Years" };
        }

        // rules to change the visibility based on ChangeVisilibityProperty's value
        protected override void InitializeRules()
        {
            base.InitializeRules();
            Rule("AdjustMethod", () =>
            {
                switch(GetStringValue(AdjustMethod.Value))
                {
                    case "Add":
                        Value.IsVisible = true;
                        Units.IsVisible = true;
                        break;
                    case "Substract":
                        Value.IsVisible = true;
                        Units.IsVisible = true;
                        break;
                    default:
                        Value.IsVisible = false;
                        Units.IsVisible = false;
                        break;
                }
            });
        }

        // updates properties only when this property changes
        protected override void ManualRegisterDependencies()
        {
            RegisterDependency(AdjustMethod, nameof(AdjustMethod.Value), "AdjustMethod");
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
