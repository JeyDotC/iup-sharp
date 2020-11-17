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
            using (var app = new IupApp())
            {
                var vBox = new IupVBox(
                    new IupButton
                    {
                        Title = "Hello World",
                        Expand = IupExpandMode.Horizontal,
                    }.OnAction((o, h) => Console.WriteLine("Clicked.")),
                    new IupButton
                    {
                        Title = "Hello World 2",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Title = "Inactive Button",
                        Expand = IupExpandMode.Horizontal,
                        Active = false
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                    }
                );

                var scrollBox = new IupScrollBox(vBox);
                var window = new IupDialog(scrollBox)
                {
                    BgColor = Color.White,
                    Title = "Hello World",
                    Size = IupSize.Half,
                };

                window.Title = $"The VBox has {vBox.ChildCount} children";

                foreach (var button in vBox.Children.Cast<IupButton>())
                {
                    button.Size = "x30";
                }

                window.OnResize((obj, args) => Console.WriteLine("Refresh Supported!"));
                window.OnResize((obj, args) => Console.WriteLine("Multi-Refresh Supported!"));

                window.ShowXY(Iup.IUP_CENTER, Iup.IUP_CENTER);

                app.MainLoop();
            }
        }

    }
}
