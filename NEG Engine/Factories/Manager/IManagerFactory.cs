using NEG_Engine.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Manager
{
    interface IManagerFactory
    {
        IManager GetManager(Func<IManager> NewHitbox);
    }
}
