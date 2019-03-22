using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Hitbox
{
    abstract class AbstractHitbox : IHitbox
    {
        #region Variables
        protected   Point       _origin;
        protected   Point       _size;

        #endregion

        public AbstractHitbox(Point Origin, Point Size)
        {
            _origin = Origin;
            _size = Size;
        }

        #region Inherited methods
        public Point Origin
        {
            get { return _origin;   }
            set { _origin = value;  }
        }
        public Point Size
        {
            get { return _size;     }
            set { _size = value;    }
        }

        public Rectangle GetHitboxArea()
        {
            return new Rectangle(_origin, new Size(_size));
        }

        public abstract void OnCollission(IHitbox CollidedWith, long Ticks);                    

        #endregion
    }
}
