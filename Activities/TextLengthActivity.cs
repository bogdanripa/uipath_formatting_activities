using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UiPathTeam.BasicTypes.Activities
{
    [ExcludeFromCodeCoverage]
    public class TextLengthActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public OutArgument<int> Length { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (InputText.Get(context) is not null)
            {
                Length.Set(context, InputText.Get(context).Length);
            }
            else
            {
                Length.Set(context, 0);
            }
        }
    }
}
