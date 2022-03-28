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
    public partial class TextLengthActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }

        public DesignOutArgument<int> Length { get; set; }

        public TextLengthActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.TextLength_Property_InputText;

            Length.IsPrincipal = false;
            Length.IsVisible = true;
            Length.DisplayName = Resource1.TextLength_Property_Length;
        }
    }
}
