using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.ManagerAdmin
{
    interface IManagerAdmin
    {
        bool        AddToManagerList            (IManager NewManager);

        IManager    GetManager                  (int Index);
        IManager    GetManager                  (string ManagerTag);

        bool        RemoveManagerFromList       (int Index);
        bool        RemoveManagerFromList       (string ManagerTag);
    }
}
