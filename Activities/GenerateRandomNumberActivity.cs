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
    public class GenerateRandomNumberActivity : CodeActivity
    {
        public InArgument<int> From { get; set; }
        public InArgument<int> To { get; set; }
        public OutArgument<int> RandomNumber { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            Random rand = new Random();
            RandomNumber.Set(context, rand.Next(From.Get(context), To.Get(context)));
        }
    }
}
