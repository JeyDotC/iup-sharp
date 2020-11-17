using IUPSharp;
using IUPSharp.UI;
using IUPSharp.UI.Controls.Containers;
using IUPSharp.UI.Controls.Standard;
using IUPSharp.UI.Dialogs;
using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace IUPBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Iup.IupOpen(IntPtr.Zero, args);

             var input = Iup.IupText("NoAction");

             var entries = Iup.IupVboxv(
                 Iup.IupLabel("Hello World from IUP 1."),
                 Iup.IupLabel("Hello World from IUP 2."),
                 Iup.IupLabel("Hello World from IUP 3.")
             );

             var myCoolButton = Iup.IupFlatButton("Add Entry");
             Iup.IupSetAttributes(myCoolButton, @"BGCOLOR=""51 148 204"", PADDING=2x2, FGCOLOR=""255 255 255""");

             Iup.IupSetCallback(myCoolButton, "FLAT_ACTION", button =>
             {
                 var value = Iup.IupGetAttribute(input, "VALUE");

                 Iup.IupSetAttribute(input, "VALUE", string.Empty);

                 var newLabel = Iup.IupLabel(value);
                 var parent = Iup.IupAppend(entries, newLabel);
                 var mapResult = Iup.IupMap(newLabel);

                 Iup.IupRefresh(parent);
                 return Iup.IUP_NOERROR;
             });

             var clearButton = Iup.IupButton("Clear Stuff", "Clear");
             Iup.IupSetCallback(clearButton, "ACTION", button =>
             {
                 var child = Iup.IupGetChild(entries, 0);

                 while(child != IntPtr.Zero)
                 {
                     Iup.IupDetach(child);
                     child = Iup.IupGetChild(entries, 0);
                 }

                 Iup.IupRefresh(entries);

                 return Iup.IUP_NOERROR;
             });

             var layout = Iup.IupVboxv(
                 input,
                 entries,
                 Iup.IupHboxv(myCoolButton, clearButton)
             );

             var dialog = Iup.IupDialog(layout);

             Iup.IupSetAttribute(dialog, "TITLE", "Hello World 5"); // For some reason, the title never displays.
             Iup.IupSetAttribute(dialog, "SIZE", "300x90");
             Iup.IupShowXY(dialog, Iup.IUP_CENTER, Iup.IUP_CENTER);

             Iup.IupMainLoop();

             Iup.IupClose();*/
            using (var app = new IupApp())
            {
                var window = new IupDialog(new ScrollBox(new VBox(
                    new IupButton
                    {
                        Title = "Hello World",
                        Expand = IupExpandMode.Horizontal,
                        Size="x100",
                    },
                    new IupButton
                    {
                        Title = "Hello World 2",
                        Expand = IupExpandMode.Horizontal,
                        Size = "x100",
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                        Size = "x100",
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                        Size = "x100",
                    },
                    new IupButton
                    {
                        Title = "Inactive Button",
                        Expand = IupExpandMode.Horizontal,
                        Size = "x100",
                        Active = false
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                        Size = "x100",
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                        Size = "x100",
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                        Size = "x100",
                    }
                )))
                {
                    BgColor = Color.White,
                    Title = "Hello World",
                    Size = IupSize.Half,
                };

                window.ShowXY(Iup.IUP_CENTER, Iup.IUP_CENTER);

                app.MainLoop();
            }
        }
    }
}
