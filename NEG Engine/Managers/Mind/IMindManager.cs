using NEG_Engine.Factories.Mind;
using NEG_Engine.Mind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.Mind
{
    interface IMindManager
    {
        bool AddMindToMindList(IMind Mind);

        bool RemoveMindFromList(IMind Mind);
        bool RemoveMindFromList(int Index);

        IMind[] FindMind(string MindTag);
        IMindFactory GetMindFactory();
    }
}
