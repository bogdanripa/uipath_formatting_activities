using System;
using System.Activities;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;

namespace UiPathTeam.BasicTypes.Activities
{
    [ExcludeFromCodeCoverage]
    public class FormatNumberActivity : CodeActivity
    {
        public InArgument<double> Number { get; set; }
        public InArgument<int> Decimals { get; set; }
        public InArgument<string> DecimalSeparator { get; set; }
        public InArgument<string> ThousandSeparator { get; set; }
        public OutArgument<string> Text { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                double number = Number.Get(context);
                int decimals = Decimals.Get(context);
                string ds = DecimalSeparator.Get(context);
                string ts = ThousandSeparator.Get(context);

                if (ds == "None" || ds == null) ds = "";
                if (ts == "None" || ts == null) ts = "";

                if (ds != "") ds = ds.Substring(0, 1);
                if (ts != "") ts = ts.Substring(0, 1);

                string intPart = String.Format("{0:0,0.}", number);
                intPart = intPart.Replace(",", ts);

                string decimalsPart = "";
                if (decimals > 0)
                {
                    decimalsPart = String.Format("{0:." + String.Concat(Enumerable.Repeat("0", decimals)) + "}", number);
                    decimalsPart = decimalsPart.Substring(decimalsPart.IndexOf(".") + 1);
                    if (ds == null || ds == "")
                        ds = ".";

                    decimalsPart = ds + decimalsPart;
                }

                Text.Set(context, intPart + decimalsPart);
            }
            catch (Exception e)
            {
                throw new Exception("Error converting number (" + Number.Get(context) + ") to text");
            }
        }
    }
}
