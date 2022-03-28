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
    public class TrimTextActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public InArgument<string> Direction { get; set; }
        public OutArgument<string> TrimmedText { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (InputText.Get(context) is not null)
            {
                string text = InputText.Get(context);
                switch(Direction.Get(context))
                {
                    case "Leading":
                        text = text.TrimStart();
                        break;
                    case "Trailing":
                        text = text.TrimEnd();
                        break;
                    default:
                        text = text.Trim();
                        break;
                }

                TrimmedText.Set(context, text);
            }
            else
            {
                TrimmedText.Set(context, null);
            }
        }
    }
}
