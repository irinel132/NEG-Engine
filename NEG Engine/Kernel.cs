using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEG_Engine
{
    class Kernel
    {
        // internal variables
        protected Form _gameWindow = null;



        public Kernel (Form F)
        {
            this._gameWindow = F;
        }
    }
}
