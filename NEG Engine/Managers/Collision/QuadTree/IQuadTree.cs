using NEG_Engine.Hitbox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.Collision.QuadTree
{
    interface IQuadTree
    {
        Rectangle GetArea                       ();

        void AddHitboxToList                    (IHitbox Hitbox);

        void RemoveHitboxFromList               (IHitbox Hitbox);

        IHitbox[]   GetHitboxArray              ();
        IHitbox[]   GetPossibleCollisions       (IHitbox Hitbox);

        void        UpdateAllHitboxes           ();

        void        End                         ();

        int         GetHitboxCount              ();
    }
}
