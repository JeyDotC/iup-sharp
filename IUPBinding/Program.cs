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
            using var app = new IupApp();
            var itemsVBox = new IupVBox(
                new IupButton
                {
                    Title = "Hello World",
                    Expand = IupExpandMode.Horizontal,
                }.With(button =>
                {
                    button.Action += (o, h) =>
                    {
                        var helloWorld2 = button.Parent.GetByName<IupButton>("HelloWorld2");
                        helloWorld2.Title = "Oh, you found me!";
                    };
                }),
                new IupButton
                {
                    Name = "HelloWorld2",
                    Title = "Hello World 2",
                    Expand = IupExpandMode.Horizontal,
                }.With(b =>
                {
                    b.FocusIn += (o, e) => b.Title = "What are you doing step user?";
                    b.FocusOut += (o, e) => b.Title = "Hello World 2";
                }),
                new IupButton
                {
                    Name = "HelloWorld3",
                    Title = "Hello World 3",
                    Expand = IupExpandMode.Horizontal,
                }.With(button =>
                {
                    button.Action += (o, a) => button.Root.Title = "Buahahahaha, I changed the title!";
                }),
                new IupButton
                {
                    Title = "Hide Console Window",
                    Expand = IupExpandMode.Horizontal,
                }.With(b =>
                {
                    b.Action += (o, e) => app.ShowConsoleWindow = false;
                }),
                new IupButton
                {
                    Title = "Inactive Button",
                    Expand = IupExpandMode.Horizontal,
                    Active = false
                },
                new IupButton
                {
                    Title = "Show Console Window",
                    Expand = IupExpandMode.Horizontal,
                }.With(b =>
                {
                    b.Action += (o, e) => app.ShowConsoleWindow = true;
                }),
                new IupButton
                {
                    Title = "Close the app",
                    Expand = IupExpandMode.Horizontal,
                    Tip = "I'll close the App",
                }.With(b =>
                {
                    b.Action += (o, e) => Iup.IupExitLoop();
                }),
                new IupButton
                {
                    Title = "Hello World 7",
                    Expand = IupExpandMode.Horizontal,
                }
            );

            var window = new IupDialog(new IupVBox(
                        new IupText().With(text =>
                        {
                            text.Expand = IupExpandMode.Horizontal;
                        }),
                        new IupScrollBox(itemsVBox)
                    )
                )
            {
                BgColor = Color.White,
                Title = "Hello World",
                Size = IupSize.Half,
            }.With(w =>
            {
                w.Resize += (obj, args) => Console.WriteLine("Window Resized");
            });

            window.Title = $"The VBox has {itemsVBox.ChildCount} children";

            foreach (var button in itemsVBox.Children.OfType<IupButton>())
            {
                button.Size = "x40";
            }

            window.ShowCentered();

            //app.ShowConsoleWindow = false;

            app.MainLoop();
        }

    }
}
