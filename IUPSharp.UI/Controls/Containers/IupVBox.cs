﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IUPSharp.UI.Controls.Containers
{
    public class IupVBox : IupContainerControl
    {
        public IupVBox(params IupObject[] children) : base(Iup.IupVboxv(), children)
        {
        }
    }
}
