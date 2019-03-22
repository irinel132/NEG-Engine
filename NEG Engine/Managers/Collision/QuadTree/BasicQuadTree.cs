using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using NEG_Engine.Factories.QuadTree;
using NEG_Engine.Hitbox;

namespace NEG_Engine.Managers.Collision.QuadTree
{
    class BasicQuadTree : IQuadTree, IDisposable
    {
        #region Variables
        protected static readonly int MAX_NODES = 10;

        protected int _level = 0;

        protected List<IHitbox> _nodes  = null;
        protected IQuadTree[]   _leaves = null;
        protected IQuadTree     _trunk  = null;
        protected Rectangle     _area;

        #endregion

        public BasicQuadTree(Rectangle Area, int Level, IQuadTree Trunk)
        {
            _area   = Area;
            _level  = Level;
            _trunk  = Trunk;

            _nodes  = new List<IHitbox>();
        }

        #region Inherited Methods

        public void AddHitboxToList(IHitbox Hitbox)
        {
            if (!Hitbox.GetHitboxArea().IntersectsWith(_area) && 
                _level > 0)
            {
                _trunk.AddHitboxToList(Hitbox);
            }

            if (_nodes.Count() < MAX_NODES)
            {
                _nodes.Add(Hitbox);

                return;
            }

            if (_leaves == null) { Bloom(); }

            foreach (IQuadTree QT in _leaves)
            {
                if (QT.GetArea().IntersectsWith(Hitbox.GetHitboxArea()))
                {
                    QT.AddHitboxToList(Hitbox);

                    return;
                }
            }
        }

        public void Dispose()
        {
            _nodes = null;            
            DisposeLeaves();
        }

        public void End()
        {
            Dispose();
        }

        public Rectangle GetArea()
        {
            return _area;
        }

        public IHitbox[] GetHitboxArray()
        {
            List<IHitbox> hitboxList = new List<IHitbox>();

            hitboxList.AddRange(_nodes);
            if (_leaves != null)
            {
                foreach (IQuadTree QT in _leaves)
                    hitboxList.AddRange(QT.GetHitboxArray());
            }            

            return hitboxList.ToArray();
        }

        public IHitbox[] GetPossibleCollisions(IHitbox Hitbox)
        {
            List<IHitbox> possibleCollisions = new List<IHitbox>();

            if (Hitbox.GetHitboxArea().IntersectsWith(_area))
            {
                possibleCollisions.AddRange(_nodes);

                if (_leaves != null)
                    foreach (IQuadTree QT in _leaves)
                        possibleCollisions.AddRange(QT.GetPossibleCollisions(Hitbox));
            }

            return possibleCollisions.ToArray();
        }

        public void RemoveHitboxFromList(IHitbox Hitbox)
        {
            _nodes.Remove(Hitbox);

            foreach (IQuadTree QT in _leaves)
                QT.RemoveHitboxFromList(Hitbox);

            TryToDisposeLeaves();
        }

        public void UpdateAllHitboxes()
        {            
            if (_leaves != null)
            {
                foreach (IQuadTree QT in _leaves)
                    QT.UpdateAllHitboxes();
            }  
            
            foreach (IHitbox QT in _nodes)
            {
                UpdateHitbox(QT);
            }

            TryToDisposeLeaves();
        }

        #endregion

        #region Methods
        protected void UpdateHitbox(IHitbox Hitbox)
        {
            if (_level > 0  && 
                !Hitbox.GetHitboxArea().IntersectsWith(_area))
            {
                IHitbox HitboxCopy = Hitbox;    // Extra safety. Comment it out if you dare
                RemoveHitboxFromList(Hitbox);

                _trunk.AddHitboxToList(HitboxCopy);
            }
        }

        protected void Bloom()      // Initializes the _leaves
        {
            _leaves     = new IQuadTree[4];

            int x = _area.X, 
                y = _area.Y, 
                w = _area.Width     / 2, 
                h = _area.Height    / 2;

            _leaves[0] = NewLeaf(x      , y     , w, h);
            _leaves[1] = NewLeaf(x + w  , y     , w, h);
            _leaves[2] = NewLeaf(x      , y + h , w, h);
            _leaves[3] = NewLeaf(x + w  , y + h , w, h);

        }

        protected IQuadTree NewLeaf (int x, int y, int w, int h)
        {
            return QuadTreeFactory.GetNewQuadTree
            (
                () => new BasicQuadTree
                    (
                     new Rectangle(x, y, w, h),
                     _level + 1,
                     this
                    )
            );
        }

        protected void TryToDisposeLeaves()
        {
            if (LeavesAreEmpty()) { DisposeLeaves(); }
        }

        protected bool LeavesAreEmpty()
        {
            if (_leaves == null) { return false; } // Already disposed/empty. No need to act
            bool    condition   = true;
            int     i           = 0;

            while (condition && i < _leaves.Length)
            {
                if (_leaves[i].GetHitboxCount() > 0)
                    condition = false;
                i++;
            }

            return condition;
        }

        protected void DisposeLeaves()
        {
            for (int i = 0; i < _leaves.Length; i++)
            {
                _leaves[i].End();
                _leaves[i] = null;
            }

            _leaves = null;
        }

        public int GetHitboxCount()
        {
            int hitboxCount = _nodes.Count();

            if (_leaves != null)
            {
                foreach (IQuadTree QT in _leaves)
                    hitboxCount += QT.GetHitboxCount();
            }            

            return hitboxCount;
        }
        #endregion
    }
}
