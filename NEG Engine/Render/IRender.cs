using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
namespace NEG_Engine.Render
{
    interface IRender
    {
        void DrawBitmap (Bitmap BMP, Point Position);
        void DrawBitmap (Bitmap BMP, int X, int Y);
        void DrawBitmap(Bitmap BMP, Point Position, float Scale, bool Flipped);

        void NextFrame ();
    }
}
