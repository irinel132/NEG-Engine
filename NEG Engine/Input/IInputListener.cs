using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEG_Engine.Input
{
    interface IInputListener
    {        
        void KeyDown(object sender, KeyEventArgs e);
    }
}
