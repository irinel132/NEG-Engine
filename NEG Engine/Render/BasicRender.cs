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
        protected Form      _form           = null;
        protected Graphics  _formGraphics   = null;        

        protected Bitmap    _nextFrame          = null;
        protected Graphics  _nextFrameGraphics  = null;
        // Constructor

        public BasicRender (Form Form, Point Resolution)
        {
            _form           = Form;                     // Assign the form to a variable
            _formGraphics   = Form.CreateGraphics();    // Get the graphics from the form and assign it to a variable

            
            _nextFrame = new Bitmap(Resolution.X, Resolution.Y);    // Create a new Bitmap the size of the resolution
            _nextFrameGraphics = Graphics.FromImage(_nextFrame);    // Create a graphics for that bitmap
        }

        // Methods
        public void DrawBitmap(Bitmap BMP, Point Position)
        {
            _nextFrameGraphics.DrawImage(BMP, Position);
        }

        public void DrawBitmap(Bitmap BMP, int X, int Y)
        {
            _nextFrameGraphics.DrawImage(BMP, X, Y);
        }

        public void NextFrame()
        {           
            _formGraphics.DrawImage(_nextFrame, 0, 0);

            _nextFrameGraphics.Clear(Color.Orange);
        }
    }
}
