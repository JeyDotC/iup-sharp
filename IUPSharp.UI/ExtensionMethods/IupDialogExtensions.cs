using IUPSharp.UI.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUPSharp.UI
{
    public static class IupDialogExtensions
    {
        public static IupDialog ShowCentered(this IupDialog dialog)
        {
            dialog.ShowXY(Iup.IUP_CENTER, Iup.IUP_CENTER);

            return dialog;
        }
    }
}
