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
    public partial class SearchAndReplaceInTextActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<string> InputText { get; set; }
        public DesignInArgument<string> Search { get; set; }
        public DesignInArgument<string> Replace { get; set; }
        public DesignInArgument<bool> UseRegex { get; set; }
        public DesignOutArgument<string> Result { get; set; }

        public SearchAndReplaceInTextActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputText.IsPrincipal = true;
            InputText.IsRequired = true;
            InputText.DisplayName = Resource1.SearchAndReplaceInText_Property_InputText;

            Search.IsPrincipal = true;
            Search.IsRequired = true;
            Search.DisplayName = Resource1.SearchAndReplaceInText_Property_Search;

            Replace.IsPrincipal = true;
            Replace.IsRequired = false;
            Replace.DisplayName = Resource1.SearchAndReplaceInText_Property_Replace;

            UseRegex.IsPrincipal = false;
            UseRegex.IsVisible = true;
            UseRegex.DisplayName = Resource1.SearchAndReplaceInText_Property_UseRegex;
            UseRegex.Widget = new DefaultWidget() { Type = "nullableboolean" };
            if (UseRegex.Value is null)
            {
                UseRegex.Value = false;
            }

            Result.IsPrincipal = false;
            Result.IsVisible = true;
            Result.DisplayName = Resource1.SearchAndReplaceInText_Property_Result;
        }
    }
}
