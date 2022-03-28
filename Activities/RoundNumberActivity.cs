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
    public class RoundNumberActivity : CodeActivity
    {
        public InArgument<double> InputNumber { get; set; }
        public InArgument<int> Decimals { get; set; }
        public OutArgument<double> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int decimals = Decimals.Get(context);
            Result.Set(context, Math.Round(InputNumber.Get(context), decimals));
        }
    }
}
