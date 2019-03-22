using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Game
{
    class Game
    {
        public Kernel _kernel = null;

        public Game(Kernel Kernel)
        {
            _kernel = Kernel;

            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(200, 0)  , .45f, true, 0));
            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(200, 200), .45f, true, 0));
            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(200, 400), .45f, true, 0));
            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(200, 600), .45f, true, 0));



            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(1500, 0)  , .45f, false, 0));
            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(1500, 200), .45f, false, 0));
            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(1500, 400), .45f, false, 0));
            Factories.Sprite.SpriteFactory.GetNewSprite(() => new Sprites.TestSprite(2, new Point(1500, 600), .45f, false, 0));
        }
    }
}
