using NEG_Engine.Managers.Mind;
using NEG_Engine.Mind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Mind
{
    class MindFactory : AbstractFactory<IMind>
    {
        #region Variables
        protected static IMindManager   _mindManager    = null;
        protected static int            _index          = 0;
        #endregion

        public static void SetMindManager (IMindManager MindManager)
        {
            _mindManager = MindManager;
        }

        public static IMind GetNewMind(Func<IMind> NewMind)
        {
            if (_mindManager == null) { return null; }

            Register(_index, NewMind);

            IMind mind = Create(_index++);

            _mindManager.AddMindToMindList(mind);

            return mind;
        }
    }
}
