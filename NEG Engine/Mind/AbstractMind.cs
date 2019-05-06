using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NEG_Engine.Managers.ManagerAdmin;
using NEG_Engine.Managers.Mind;

namespace NEG_Engine.Mind
{
    abstract class AbstractMind : IMind
    {
        #region Variables
        public static string MIND_TAG = "DEFAULT";
        // Internal variables
        protected   IMindManager  _mindManager  = null;  // Reference to the mind manager     
        protected   IManagerAdmin _managerAdmin = null;

        public string GetMindTag()
        {
            return MIND_TAG;
        }
        #endregion

        #region Interface methods

        public void Setup(IMindManager MindManager, IManagerAdmin ManagerAdmin)
        {
            _mindManager    = MindManager;  // Store the mind manager in the internal variable
            _managerAdmin   = ManagerAdmin;
        }

        public abstract void Tick(long Tick);

        #endregion
    }
}
