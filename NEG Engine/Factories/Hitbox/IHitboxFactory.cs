using NEG_Engine.Hitbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Hitbox
{
    interface IHitboxFactory
    {
        void RegisterHitbox(IHitbox Hitbox);

        IHitbox GetHitbox(Func<IHitbox> NewHitbox);
    }
}
