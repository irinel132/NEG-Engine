using NEG_Engine.Managers.ManagerAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers
{
    abstract class AbstractManager : IManager
    {
        // Internal variables
        protected   string  _managerTag = null;     // The string tag that identifies the class

        //Constructors
        public AbstractManager (String ManagerTag)
        {
            _managerTag = "" + ManagerTag;          // Assigning the tag, and forcing for a new string instance
        }



        public void End()
        {
            throw new NotImplementedException();
        }

        public string GetManagerTag()
        {
            return _managerTag;
        }

        public void Start(IManagerAdmin ManagerAdmin)
        {
            throw new NotImplementedException();
        }

        public void Tick(long Ticks)
        {
            throw new NotImplementedException();
        }
    }


}
