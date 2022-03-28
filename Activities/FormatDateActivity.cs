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
    public class FormatDateActivity : CodeActivity
    {
        public InArgument<DateTime> Date { get; set; }
        public InArgument<string> Format { get; set; }
        public InArgument<string> Custom { get; set; }
        public OutArgument<string> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                Text.Set(context, Date.Get(context).ToString(Custom.Get(context)));
            }
            catch (Exception e)
            {
                throw new Exception("Error converting date (" + Date.Get(context) + ") to text (" + Custom.Get(context) + ")");
            }
        }
    }
}
