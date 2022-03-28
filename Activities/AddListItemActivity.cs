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
    public class AddListItemActivity<T> : CodeActivity
    {
        public InOutArgument<IEnumerable<T>> InputList { get; set; }
        public InArgument<T> Item { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            IEnumerable<T> l = InputList.Get(context);

            if (l is null)
            {
                l = new List<T>();
            }

/*            if (false || l.GetType().IsArray)
            {
                T[] la = l.ToArray();
                la.Concat(new T[] { });
            }
            else*/

            l = l.Concat(new T[] { Item.Get(context) });

            //IEnumerable<T> a = new List<T>();

            InputList.Set(context, l);
        }
    }
}
