using NEG_Engine.Managers.Collision.QuadTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.QuadTree
{
    interface IQuadTreeFactory
    {
        IQuadTree GetNewQuadTree(Func<IQuadTree> NewQuadTree);
    }
}
