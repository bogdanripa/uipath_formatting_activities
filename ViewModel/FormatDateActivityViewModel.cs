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
    public partial class FormatDateActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<DateTime> Date { get; set; }
        public DesignInArgument<string> Format { get; set; }
        public DesignInArgument<string> Custom { get; set; }
        public DesignOutArgument<string> Text { get; set; }

        private DataSource<string> _formatsDataSource;
        public FormatDateActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            Date.IsPrincipal = true;
            Date.IsRequired = true;
            Date.DisplayName = Resource1.FormatDate_Property_Date;

            Format.IsPrincipal = true;
            Format.IsRequired = true;
            Format.DisplayName = Resource1.FormatDate_Property_Format;

            Custom.IsPrincipal = true;
            Custom.IsVisible = false;
            Custom.DisplayName = Resource1.FormatDate_Property_Custom;
            Custom.Tooltip = Resource1.FormatDate_Property_CustomTooltip;

            Text.IsPrincipal = false;
            Text.IsVisible = true;
            Text.DisplayName = Resource1.FormatDate_Property_Text;


            // data source for the dropdown
            _formatsDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            Format.DataSource = _formatsDataSource;

            Format.Widget = new DefaultWidget() { Type = "Dropdown" };

            //dropdown values
            _formatsDataSource.Data = new string[9] { "MM/dd/yyyy", "dd-MM-yyyy", "d MMM yyyy", "HH:mm:ss", "HH:mm", "hh:mm tt", "MM/dd/yyyy HH:mm:ss", "d MMM yyyy hh:mm tt", "Custom"};

            if (Format.Value is null)
            {
                Format.Value = _formatsDataSource.Data[0];
            }

            if (GetStringValue(Format.Value) == "Custom")
            {
                Custom.IsVisible = true;
            }
        }

        protected override void InitializeRules()
        {
            base.InitializeRules();
            Rule("Format", () =>
            {
                if (GetStringValue(Format.Value) == "Custom")
                {
                    Custom.IsVisible = true;
                }
                else
                {
                    Custom.IsVisible = false;
                    Custom.Value = GetStringValue(Format.Value);
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
