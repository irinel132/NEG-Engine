using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NEG_Engine.Sprite
{
    interface ISprite
    {
        Bitmap IGetSprite();

        Bitmap ISetSprite();

        Point IGetSpriteLocation();

        Point ISetSpriteLocation();

        Point IGetSpriteSize();

        Point ISetSpriteSize();

        Double IGetSpriteRotation();

        Double ISetSpriteRotation();
    }
}
