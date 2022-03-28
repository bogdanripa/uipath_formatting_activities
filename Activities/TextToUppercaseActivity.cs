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
    public class TextToUppercaseActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public OutArgument<string> UppercaseText { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (InputText.Get(context) is not null)
            {
                UppercaseText.Set(context, InputText.Get(context).ToUpper());
            }
            else
            {
                UppercaseText.Set(context, null);
            }
        }
    }
}
