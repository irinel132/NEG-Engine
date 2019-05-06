using NEG_Engine.Hitbox;
using NEG_Engine.Managers.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Hitbox
{
    class HitboxFactory : AbstractFactory<IHitbox>, IHitboxFactory
    {
        #region Variables
        protected ICollisionManager _collisionManager = null;
        protected int _index = 0;
        #endregion

        #region Methods
        public HitboxFactory (ICollisionManager CollisionManager)
        {
            _collisionManager = CollisionManager;
        }

        public void RegisterHitbox (IHitbox Hitbox)
        {
            _collisionManager.AddHitboxToList(Hitbox);
        }

        public IHitbox GetHitbox(Func<IHitbox> NewHitbox)
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
