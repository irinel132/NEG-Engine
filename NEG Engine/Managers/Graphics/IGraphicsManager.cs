using NEG_Engine.Loader.Sprite;
using NEG_Engine.Render;
using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.Graphics
{
    interface IGraphicsManager
    {
        IRender         VideoRender     { get; set; }                       // The render used in drawing sprites
        ISpriteLoader   SpriteLoader    { get; set; }                       // The sprite loader

        bool AddSpriteToRenderList (ISprite Sprite);            // Adds a sprite to the render list

        bool removeSpriteFromRenderList(ISprite Sprite);        // Will remove the sprite from the render list
        bool removeSpriteFromRenderList(int Index);             // Will remove the sprite from the render list, using the provded Indexa
    }
}
