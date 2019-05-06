using NEG_Engine.Mind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Mind
{
    interface IMindFactory
    {
        IMind GetNewMind(Func<IMind> NewMind);
    }
}
