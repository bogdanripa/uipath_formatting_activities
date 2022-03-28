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
    public partial class TextToLowercaseActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }

        public DesignOutArgument<string> LowercaseText { get; set; }

        public TextToLowercaseActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.TextToLowercase_Property_InputText;

            LowercaseText.IsPrincipal = false;
            LowercaseText.IsVisible = true;
            LowercaseText.DisplayName = Resource1.TextToLowercase_Property_LowercaseText;
        }
    }
}
