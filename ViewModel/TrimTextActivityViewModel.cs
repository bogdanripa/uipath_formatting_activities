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
    public partial class TrimTextActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }
        public DesignInArgument<string> Direction { get; set; }
        public DesignOutArgument<string> TrimmedText { get; set; }

        private DataSource<string> _dirDataSource;

        public TrimTextActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.TrimText_Property_InputText;

            Direction.IsPrincipal = false;
            Direction.IsRequired = true;
            Direction.DisplayName = Resource1.TrimText_Property_Direction;

            // data source for the dropdown
            _dirDataSource = DataSourceBuilder<string>
                .WithId(s => s)
                .WithLabel(s => s)
                .WithSingleItemConverter(
                    itemToValue: s => new InArgument<string>(s),
                    valueToItem: s => GetStringValue(s))
                .Build();
            Direction.DataSource = _dirDataSource;

            Direction.Widget = new DefaultWidget() { Type = "Dropdown" };

            _dirDataSource.Data = new string[3] { "Leading", "Trailing", "Both" };

            if (Direction.Value == null)
                Direction.Value = "Both";

            TrimmedText.IsPrincipal = false;
            TrimmedText.IsVisible = true;
            TrimmedText.DisplayName = Resource1.TrimText_Property_TrimmedText;
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
