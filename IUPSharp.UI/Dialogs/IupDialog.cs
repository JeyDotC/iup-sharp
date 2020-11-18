using IUPSharp.UI.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace IUPSharp.UI.Dialogs
{
    public sealed class IupDialog : IupControl
    {
        public IupDialog()
            : this(new IupNoObject())
        {

        }

        public IupDialog(IupObject child) : base(Iup.IupDialog(child.Handle)) {

            SetCallback("CLOSE_CB", CloseCallback);
         
            SetCallback("RESIZE_CB", ResizeCallback);
        }

        #region Properties

        public string Background
        {
            get => Get("BACKGROUND");
            set => Set("BACKGROUND", value);
        }

        /// <summary>
        /// Same as Active, but won't affect children
        /// </summary>
        public bool LocalActive
        {
            get => GetBoolean("NACTIVE");
            set => SetBoolean("NACTIVE", value);
        }

        public IupCursor Cursor
        {
            get => GetEnum<IupCursor>("CURSOR");
            set => SetEnum("CURSOR", value);
        }

        public bool SimulateModal { set => SetBoolean("SIMULATEMODAL", value); }

        #endregion

        #region Events
        
        public event EventHandler<DialogCloseArgs> Close;
        public event EventHandler<DialogResizeArgs> Resize;
        
        private int CloseCallback(IntPtr handle)
        {
            var args = new DialogCloseArgs();

            Close?.Invoke(this, args);

            return args.ShouldClose ? Iup.IUP_CLOSE : Iup.IUP_IGNORE;
        }

        private int ResizeCallback(IntPtr handle, int width, int height)
        {
            var args = new DialogResizeArgs(new Size(width, height));

            Resize?.Invoke(this, args);

            return Iup.IUP_NOERROR;
        }

        #endregion

        public void ShowXY(int x, int y) => Iup.IupShowXY(Handle, x, y);
    }

    public enum IupCursor
    {
        None,
        Arrow,
        Busy,
        Cross,
        Hand,
        Help,
        Move,
        Resize_n,
        Resize_s,
        Resize_ns,
        Resize_w,
        Resize_e,
        Resize_we,
        Resize_ne,
        Resize_sw,
        Resize_nw,
        Resize_se,
        Splitter_horiz,
        Splitter_vert,
        Text,
        Uparrow,
    }
}