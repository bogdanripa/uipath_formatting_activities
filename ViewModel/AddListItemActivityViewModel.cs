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
    public partial class AddListItemActivityViewModel<T> : DesignPropertiesViewModel
    {
        public DesignInOutArgument<IEnumerable<T>> InputList { get; set; }
        public DesignInArgument<Object> Item { get; set; }

        public AddListItemActivityViewModel(IDesignServices services) : base(services)
        {
        }

        protected override void InitializeModel()
        {
            base.InitializeModel();

            InputList.IsPrincipal = true;
            InputList.IsRequired = true;
            InputList.DisplayName = Resource1.AddListItem_Property_InputList;

            Item.IsPrincipal = true;
            Item.IsRequired = true;
            Item.DisplayName = Resource1.AddListItem_Property_Item;
        }
    }
}
