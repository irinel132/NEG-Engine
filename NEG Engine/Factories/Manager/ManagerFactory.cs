using NEG_Engine.Managers;
using NEG_Engine.Managers.ManagerAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Manager
{
    class ManagerFactory : AbstractFactory<IManager>
    {
        #region Variables
        //protected static  
        protected static IManagerAdmin _managerAdmin = null;
        protected static int _index = 0;
        #endregion

        #region Methods
        public static void SetManagerAdmin(IManagerAdmin ManagerAdmin)
        {
            _managerAdmin = ManagerAdmin;
        }

        public static IManager GetManager(Func<IManager> NewHitbox)
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
