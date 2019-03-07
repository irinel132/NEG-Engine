using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
namespace NEG_Engine.Loader.Sprite
{
    interface ISpriteLoader
    {        
        Bitmap  GetBitmap       (int Index);        // Returns the sprite, by index
    }
}
