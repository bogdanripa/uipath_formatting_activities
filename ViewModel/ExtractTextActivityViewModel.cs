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
    public partial class ExtractTextActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }
        public DesignInArgument<string> LeftText { get; set; }
        public DesignInArgument<string> RightText { get; set; }
        public DesignInArgument<bool> UseRegex { get; set; }
        public DesignOutArgument<string> Result { get; set; }

        public ExtractTextActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.ExtractText_Property_InputText;

            LeftText.IsPrincipal = true;
            LeftText.IsRequired = false;
            LeftText.DisplayName = Resource1.ExtractText_Property_LeftText;

            RightText.IsPrincipal = true;
            RightText.IsRequired = false;
            RightText.DisplayName = Resource1.ExtractText_Property_RightText;

            UseRegex.IsPrincipal = false;
            UseRegex.IsVisible = true;
            UseRegex.DisplayName = Resource1.ExtractText_Property_UseRegex;
            UseRegex.Widget = new DefaultWidget() { Type = "nullableboolean" };
            if (UseRegex.Value is null)
            {
                UseRegex.Value = false;
            }

            Result.IsPrincipal = false;
            Result.IsVisible = true;
            Result.DisplayName = Resource1.ExtractText_Property_Result;
        }
    }
}
