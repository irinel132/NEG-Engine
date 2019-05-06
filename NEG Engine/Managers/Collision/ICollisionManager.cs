using NEG_Engine.Factories.Hitbox;
using NEG_Engine.Factories.QuadTree;
using NEG_Engine.Hitbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.Collision
{
    interface ICollisionManager
    {
        void AddHitboxToList        (IHitbox Hitbox);

        void RemoveHitboxFromList   (IHitbox Hitbox);

        IHitboxFactory      GetHitboxFactory();
        IQuadTreeFactory    GetQuadTreeFactory();
    }
}
