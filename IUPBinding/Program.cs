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
                    }.With(button =>
                    {
                        button.Action += (o, h) => {
                            var helloWorld2 = button.Parent.GetByName<IupButton>("HelloWorld2");
                            helloWorld2.Title = "Oh, you found me!";
                        };
                    }),
                    new IupButton
                    {
                        Name = "HelloWorld2",
                        Title = "Hello World 2",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Name = "HelloWorld3",
                        Title = "Hello World 3",
                        Expand = IupExpandMode.Horizontal,
                    }.With(button => {
                        button.Action += (o, a) => button.Root.Title = "Buahahahaha, I changed the title!";
                    }),
                    new IupButton
                    {
                        Title = "Hello World 4",
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
                        Title = "Hello World 5",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Title = "Hello World 6",
                        Expand = IupExpandMode.Horizontal,
                    },
                    new IupButton
                    {
                        Title = "Hello World 7",
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
                    button.Size = "x40";
                }

                window.Resize += (obj, args) => Console.WriteLine("Resize Supported!");

                window.ShowXY(Iup.IUP_CENTER, Iup.IUP_CENTER);

                Console.WriteLine($"Powered by IUP V {app.Version}");

                app.MainLoop();
            }
        }

    }
}
