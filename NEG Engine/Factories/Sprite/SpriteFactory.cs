using NEG_Engine.Managers.Graphics;
using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Sprite
{
    class SpriteFactory : AbstractFactory<ISprite>, ISpriteFactory
    {
        protected IGraphicsManager  _graphicsManager = null;
        protected int               _index ;

        public SpriteFactory (IGraphicsManager GraphicsManager)
        {
            _graphicsManager    = GraphicsManager;
            _index              = 0;
        }

        public ISprite GetNewSprite(Func<ISprite> NewSprite)
        {
            // If the graphics manager isn't set, return early
            if (_graphicsManager == null) { return null; }

            // Register the new sprite
            Register(_index, NewSprite);

            // Create the variable and create
            ISprite sprite = Create(_index++);

            // Add the sprite to the graphics manager
            _graphicsManager.AddSpriteToRenderList(sprite);            

            // Also return
            return sprite;

        }
    }
}
