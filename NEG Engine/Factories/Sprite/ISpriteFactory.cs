using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Sprite
{
    interface ISpriteFactory
    {
        ISprite GetNewSprite(Func<ISprite> NewSprite);
    }
}
