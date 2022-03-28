using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace UiPathTeam.BasicTypes.Activities
{
    [ExcludeFromCodeCoverage]
    public class SearchAndReplaceInTextActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public InArgument<string> Search { get; set; }
        public InArgument<string> Replace { get; set; }
        public InArgument<bool> UseRegex { get; set; }
        public OutArgument<string> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (InputText.Get(context) is null)
            {
                Result.Set(context, null);
            } 
            else if (Search.Get(context) is null)
            {
                Result.Set(context, InputText.Get(context));
            }
            else if (Replace.Get(context) is null)
            {
                if (UseRegex.Get(context))
                {
                    Result.Set(context, Regex.Replace(InputText.Get(context), Search.Get(context), ""));
                }
                else
                {
                    Result.Set(context, InputText.Get(context).Replace(Search.Get(context), ""));
                }
            } else
            {
                if (UseRegex.Get(context))
                {
                    Result.Set(context, Regex.Replace(InputText.Get(context), Search.Get(context), Replace.Get(context)));
                }
                else
                {
                    Result.Set(context, InputText.Get(context).Replace(Search.Get(context), Replace.Get(context)));
                }
            }
        }
    }
}
