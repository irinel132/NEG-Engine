using NEG_Engine.Managers;
using NEG_Engine.Managers.ManagerAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Manager
{
    class ManagerFactory : AbstractFactory<IManager>, IManagerFactory
    {
        #region Variables
        //protected static  
        protected IManagerAdmin _managerAdmin = null;
        protected int _index = 0;
        #endregion

        #region Methods
        public ManagerFactory (IManagerAdmin ManagerAdmin)
        {
            _managerAdmin = ManagerAdmin;
        }

        public IManager GetManager(Func<IManager> NewHitbox)
        {
            if (_managerAdmin == null) { return null; }

            Register(_index, NewHitbox);

            IManager manager = Create(_index++);

            _managerAdmin.AddToManagerList(manager);

            return manager;
        }
        #endregion
    }
}
