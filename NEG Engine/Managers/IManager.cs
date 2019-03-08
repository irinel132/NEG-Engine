using NEG_Engine.Managers.ManagerAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers
{
    interface IManager
    {
        // Starts the manager, giving it acces to ManagerAdmin for any setup required
        void    Start(IManagerAdmin ManagerAdmin);

        // Calls upon the Managers once per tick, sending in engine time (Ticks)
        void    Tick(long Ticks);

        // Calls for the desctruction of the Manager
        void    End();

        // Returns a string that represents the type of Manager
        string  GetManagerTag();

        
    }
}
