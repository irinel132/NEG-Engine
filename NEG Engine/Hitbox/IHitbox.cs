using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace NEG_Engine.Hitbox
{
    interface IHitbox
    {
       Point IGetLocation();

        Point ISetLocation();

        void IGetShape();

        void ISetShape();

        Boolean ICollidesWith();
    }
}
