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
    public partial class FormatNumberActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<double> Number { get; set; }
        public DesignInArgument<int> Decimals { get; set; }
        public DesignInArgument<string> DecimalSeparator { get; set; }
        public DesignInArgument<string> ThousandSeparator { get; set; }
        public DesignOutArgument<string> Text { get; set; }

        private DataSource<string> _dsDataSource;
        private DataSource<string> _tsDataSource;


        public FormatNumberActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            Number.IsPrincipal = true;
            Number.IsRequired = true;
            Number.DisplayName = Resource1.FormatNumber_Property_Number;

            Decimals.IsPrincipal = true;
            Decimals.IsRequired = true;
            Decimals.DisplayName = Resource1.FormatNumber_Property_Decimals;

            DecimalSeparator.IsPrincipal = true;
            DecimalSeparator.IsRequired = false;
            DecimalSeparator.DisplayName = Resource1.FormatNumber_Property_DecimalSeparator;

            // data source for the dropdown
            _dsDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            DecimalSeparator.DataSource = _dsDataSource;
            DecimalSeparator.Widget = new DefaultWidget() { Type = "AutoCompleteForExpression" };
            _dsDataSource.Data = new string[5] { ".", ",", "٫ (Arabic)", "·", "⎖" };

            ThousandSeparator.IsPrincipal = true;
            ThousandSeparator.IsVisible = true;
            ThousandSeparator.DisplayName = Resource1.FormatNumber_Property_ThousandSeparator;

            // data source for the dropdown
            _tsDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            ThousandSeparator.DataSource = _tsDataSource;
            ThousandSeparator.Widget = new DefaultWidget() { Type = "AutoCompleteForExpression" };
            _tsDataSource.Data = new string[8] { ",", ".", " (Space)", "'", "_", "٬ (Arabic)", "·", "˙" };

            Text.IsPrincipal = false;
            Text.IsVisible = true;
            Text.DisplayName = Resource1.FormatNumber_Property_Text;

            if (Decimals.Value is null)
                Decimals.Value = 2;

            if (DecimalSeparator.Value is null)
                DecimalSeparator.Value = ".";

            if (ThousandSeparator.Value is null)
                ThousandSeparator.Value = ",";
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
