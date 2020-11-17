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
        }


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