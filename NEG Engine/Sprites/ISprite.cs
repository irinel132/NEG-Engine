using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Sprites
{
    interface ISprite
    {
        Bitmap      Sprite          { get; set; }               // The Bitmap of the sprite

        Point       Scale           { get; set; }               // Scale in X and Y coordinates. 100 is standard
        Point       Position        { get; set; }               // The in engine position of the sprite

        float       Rotation        { get; set; }               // Rotation of the sprite in degrees

        bool        Flipped         { get; set; }               // True if the sprite is flipped vertically

        
    }
}
