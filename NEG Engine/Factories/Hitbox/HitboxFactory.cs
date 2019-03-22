using NEG_Engine.Hitbox;
using NEG_Engine.Managers.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Hitbox
{
    class HitboxFactory : AbstractFactory<IHitbox>
    {
        #region Variables
        protected static ICollisionManager _collisionManager = null;

        protected static int _index = 0;
        #endregion

        #region Methods
        public static void SetCollisionManager(ICollisionManager CollisionManager)
        {
            _collisionManager = CollisionManager;
        }

        public static void RegisterHitbox (IHitbox Hitbox)
        {
            _collisionManager.AddHitboxToList(Hitbox);
        }

        public static IHitbox GetHitbox(Func<IHitbox> NewHitbox)
        {
            if (_collisionManager == null) { return null; }

            Register(_index, NewHitbox);

            IHitbox hitbox = Create(_index++);

            _collisionManager.AddHitboxToList(hitbox);

            return hitbox;
        }
        #endregion
    }
}
