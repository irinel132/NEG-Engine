using NEG_Engine.Managers.ManagerAdmin;
using NEG_Engine.Managers.Mind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Mind
{
    interface IMind
    {
        void Setup(IMindManager MindManager, IManagerAdmin ManagerAdmin);
        void Tick(long Tick);       

        string GetMindTag();
    }
}
