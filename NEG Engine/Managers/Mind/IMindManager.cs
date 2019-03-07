using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.Mind
{
    interface IMindManager
    {
        void IStart();

        void ITick(long Ticks);

        void IEnd();
    }
}
