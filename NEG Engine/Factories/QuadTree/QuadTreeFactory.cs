using NEG_Engine.Managers.Collision.QuadTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.QuadTree
{
    class QuadTreeFactory : AbstractFactory<IQuadTree>
    {
        #region Variables
        protected static int _index = 0;
        #endregion


        public static IQuadTree GetNewQuadTree(Func<IQuadTree> NewQuadTree)
        {
            Register(_index, NewQuadTree);

            return Create(_index++);
        }
    }
}
