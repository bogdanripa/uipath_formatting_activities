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
    public class TextToLowercaseActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public OutArgument<string> LowercaseText { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (InputText.Get(context) is not null)
            {
                LowercaseText.Set(context, InputText.Get(context).ToLower());
            }
            else
            {
                LowercaseText.Set(context, null);
            }
        }
    }
}
