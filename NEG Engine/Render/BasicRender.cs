using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace NEG_Engine.Render
{
    class BasicRender : IRender
    {
        // Internal Variables
        protected Graphics  _graphics   = null;
        protected Form      _form       = null;
        // Constructor

        public BasicRender (Form Form)
        {
            _form       = Form;                     // Assign the form to a variable
            _graphics   = Form.CreateGraphics();    // Get the graphics from the form and assign it to a variable
        }

        // Methods
        public void DrawBitmap(Bitmap BMP, Point Position)
        {
            _graphics.DrawImage(BMP, Position);
        }
    }
}
