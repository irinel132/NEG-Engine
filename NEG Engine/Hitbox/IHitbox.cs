using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Hitbox
{
    interface IHitbox
    {
        Point       Origin    { get; set; }
        Point       Size      { get; set; }
        Rectangle   GetHitboxArea();

        void        OnCollission(IHitbox CollidedWith, long Ticks);
    }
}
