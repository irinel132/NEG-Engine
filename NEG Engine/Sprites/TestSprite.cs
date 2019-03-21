using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Sprites
{
    class TestSprite : AbstractSprite
    {
        public TestSprite(Bitmap Sprite, Point Position, Point Scale, bool Flipped, float Rotation) : base(Sprite, Position, Scale, Flipped, Rotation)
        {
        }
    }
}
