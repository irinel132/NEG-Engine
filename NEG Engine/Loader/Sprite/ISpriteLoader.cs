using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
namespace NEG_Engine.Loader.Sprite
{
    interface ISpriteLoader
    {
        void    LoadImages      ();                 // Loads all the images

        Bitmap  GetBitmap       (String Name);      // Returns the sprite, by name
        Bitmap  GetBitmap       (int Index);        // Returns the sprite, by index
    }
}
