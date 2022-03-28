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
    public partial class GetNumberFromTextActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }
        public DesignInArgument<string> Separator { get; set; }
        public DesignOutArgument<double> Number { get; set; }

        private DataSource<string> _dsDataSource;

        public GetNumberFromTextActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.GetNumberFromText_Property_InputText;

            Separator.IsPrincipal = false;
            Separator.IsRequired = false;
            Separator.DisplayName = Resource1.GetNumberFromText_Property_Separator;

            // data source for the dropdown
            _dsDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            Separator.DataSource = _dsDataSource;
            Separator.Widget = new DefaultWidget() { Type = "AutoCompleteForExpression" };
            _dsDataSource.Data = new string[6] { "Auto", ".", ",", "٫ (Arabic)", "·", "⎖" };
            if (Separator.Value == null)
                Separator.Value = "Auto";

            Number.IsPrincipal = false;
            Number.IsVisible = true;
            Number.DisplayName = Resource1.GetNumberFromText_Property_Number;
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
