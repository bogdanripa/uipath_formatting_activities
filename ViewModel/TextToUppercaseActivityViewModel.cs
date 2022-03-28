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
    public partial class TextToUppercaseActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }

        public DesignOutArgument<string> UppercaseText { get; set; }

        public TextToUppercaseActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.TextToUppercase_Property_InputText;

            UppercaseText.IsPrincipal = false;
            UppercaseText.IsVisible = true;
            UppercaseText.DisplayName = Resource1.TextToUppercase_Property_UppercaseText;
        }
    }
}
