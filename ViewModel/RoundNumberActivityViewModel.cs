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
    public partial class RoundNumberActivityViewModel : DesignPropertiesViewModel
    {
        public DesignInArgument<double> InputNumber { get; set; }

        public DesignInArgument<int> Decimals { get; set; }

        public DesignOutArgument<double> Result { get; set; }

        public RoundNumberActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputNumber.IsPrincipal = true;
            InputNumber.IsRequired = true;
            InputNumber.DisplayName = Resource1.RoundNumber_Property_InputNumber;

            Decimals.IsPrincipal = false;
            Decimals.IsRequired = true;
            Decimals.DisplayName = Resource1.RoundNumber_Property_Decimals;

            Result.IsPrincipal = false;
            Result.IsVisible = true;
            Result.DisplayName = Resource1.RoundNumber_Property_Result;

            if (Decimals.Value is null)
                Decimals.Value = 0;
        }
    }
}
