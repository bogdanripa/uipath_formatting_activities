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
    public partial class GenerateRandomNumberActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<int> From { get; set; }

        public DesignInArgument<int> To { get; set; }

        public DesignOutArgument<int> RandomNumber { get; set; }

        public GenerateRandomNumberActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            From.IsPrincipal = true;
            From.IsRequired = true;
            From.DisplayName = Resource1.GenerateRandomNumber_Property_From;

            To.IsPrincipal = true;
            To.IsRequired = true;
            To.DisplayName = Resource1.GenerateRandomNumber_Property_To;

            RandomNumber.IsPrincipal = false;
            RandomNumber.IsVisible = true;
            RandomNumber.DisplayName = Resource1.GenerateRandomNumber_Property_RandomNumber;

            if (From.Value is null)
                From.Value = 1;

            if (To.Value is null)
                To.Value = 10;
        }
    }
}
