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
    public class ExtractTextActivity : CodeActivity
    {
        public InArgument<string> InputText { get; set; }
        public InArgument<string> LeftText { get; set; }
        public InArgument<string> RightText { get; set; }
        public InArgument<bool> UseRegex { get; set; }
        public OutArgument<string> Result { get; set; }

        protected static int MyIndexOf(string str, string pattern, bool useRegex, bool addPatternLength)
        {
            if (useRegex)
            {
                var m = Regex.Match(str, pattern);
                return m.Success ? m.Index + (addPatternLength ? m.Length : 0) : -1;
            }
            else
            {
                int pos = str.IndexOf(pattern);
                if (pos >= 0 && addPatternLength) pos += pattern.Length;
                return pos;
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            string s = InputText.Get(context);
            bool useRegex = UseRegex.Get(context);
            string lt = LeftText.Get(context);
            string rt = RightText.Get(context);

            if (s == null)
            {
                Result.Set(context, null);
                return;
            }

            int left = 0;
            if (lt != null)
            {
                left = MyIndexOf(s, lt, useRegex, true);
                if (left < 0)
                {
                    Result.Set(context, null);
                    return;
                }
            }

            int length = -2;
            if (rt != null)
            {
                if (left > 0)
                {
                    length = MyIndexOf(s.Substring(left), rt, useRegex, false);
                }
                else
                {
                    length = MyIndexOf(s, rt, useRegex, false);
                }

                if (length < 0)
                {
                    Result.Set(context, null);
                    return;
                }
            }

            if (length >= 0)
            {
                Result.Set(context, s.Substring(left, length));
            }
            else
            {
                Result.Set(context, s.Substring(left));
            }   
        }
    }
}
