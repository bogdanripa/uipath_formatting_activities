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
    public class GetDateFromTextActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public InArgument<string> Culture { get; set; }
        public OutArgument<DateTime> OutDate { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                if (Culture.Get(context) is not null)
                {
                    CultureInfo culture = CultureInfo.CreateSpecificCulture(Culture.Get(context));
                    OutDate.Set(context, DateTime.Parse(InputText.Get(context), culture));
                }
                else
                {
                    OutDate.Set(context, DateTime.Parse(InputText.Get(context)));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error converting '" + InputText.Get(context) + "' to Date using " + Culture.Get(context));
            }
        }
    }
}
