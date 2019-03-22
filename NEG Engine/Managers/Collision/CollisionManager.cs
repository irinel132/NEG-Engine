using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NEG_Engine.Hitbox;
using NEG_Engine.Managers.Collision.QuadTree;
using NEG_Engine.Managers.ManagerAdmin;

namespace NEG_Engine.Managers.Collision
{
    class CollisionManager : ICollisionManager, IManager, IDisposable
    {
        #region Variables
        public static readonly string MANAGER_TAG = "CollisionManager";
        private IQuadTree   _quadTree = null;

        #endregion


        #region Inherited methods


        public void AddHitboxToList(IHitbox Hitbox)
        {
            _quadTree.AddHitboxToList(Hitbox);
        }

        public void Dispose()
        {
            _quadTree.End();
            _quadTree = null;
        }

        public void End()
        {
            Dispose();
        }

        public string GetManagerTag()
        {
            return MANAGER_TAG;
        }

        public void RemoveHitboxFromList(IHitbox Hitbox)
        {
            _quadTree.RemoveHitboxFromList(Hitbox);            
        }

        public void Start(IManagerAdmin ManagerAdmin)
        {
            Factories.Hitbox.HitboxFactory.SetCollisionManager(this);
            // Do something else here
            // Get a better sense of the total tracking area
            _quadTree = Factories.QuadTree.QuadTreeFactory.GetNewQuadTree
            (
                () => new BasicQuadTree
                    (
                        new Rectangle(int.MinValue / 2, int.MinValue / 2, int.MaxValue, int.MaxValue),
                        0,
                        null
                    )
            );
        }

        public void Tick(long Ticks)
        {
            _quadTree.UpdateAllHitboxes();

            foreach (IHitbox hitbox in _quadTree.GetHitboxArray())
            {
                IHitbox[] possibleCollisions = _quadTree.GetPossibleCollisions(hitbox);

                CheckCollisions(hitbox, possibleCollisions, Ticks);
            }
        }

        #endregion

        #region Methods
        protected void CheckCollisions(IHitbox Hitbox, IHitbox[] HitboxArray, long Ticks)
        {
            foreach (IHitbox h1 in HitboxArray)
            {
                if (Hitbox != h1)
                {
                    if (HitboxesAreColiding(Hitbox, h1))
                    {
                        Hitbox. OnCollission    (h1,        Ticks);
                        h1.     OnCollission    (Hitbox,    Ticks);
                    }
                }

            }
        }

        protected bool HitboxesAreColiding(IHitbox H1, IHitbox H2)
        {
            return H1.GetHitboxArea().IntersectsWith(H2.GetHitboxArea());
        }
        #endregion
    }
}
