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
    public class GetNumberFromTextActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public InArgument<string> Separator { get; set; }
        public OutArgument<double> Number { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string txt = InputText.Get(context);
            string sep = Separator.Get(context);
			double number;
			string digits;
			string intNum;

			if (txt == null)
			{
				//Number.Set(context, null);
				return;
			}

			if (sep == "None" || sep == "Auto" || sep == null) sep = "";
			if (sep != "") sep = sep.Substring(0, 1);

			if (sep == "")
			{
				char found = '0';
				int idx = 0;
				int foundAt = 0;

				for (int i = txt.Length - 1; i >= 0; i--)
				{
					char c = txt[i];
					if (c < '0' || c > '9')
					{
						if (found == '0') found = c;
						if (found == c)
						{
							idx++;
							if (idx == 1) foundAt = txt.Length - i;
						}

					}
				}

				if (found != '0')
				{
					if (idx == 1 && foundAt != 4)
						sep = found.ToString();
				}

			}

			if (sep != "")
			{
				if (txt.IndexOf(sep) >= 0)
				{
					digits = txt.Substring(txt.IndexOf(sep) + sep.Length);
					intNum = txt.Substring(0, txt.IndexOf(sep));
				}
				else
				{
					digits = "";
					intNum = txt;
				}
			}
			else
			{
				digits = "";
				intNum = txt;
			}

			intNum = Regex.Replace(intNum, "[^\\d-]", "");
			digits = Regex.Replace(digits, "[^\\d]", "");
			try
			{
				number = double.Parse(intNum + "." + digits);
				Number.Set(context, number);
			}
			catch (Exception e)
			{
				throw new Exception("Error parsing '" + InputText.Get(context) + "' to Number using " + sep);
			}
        }
    }
}
