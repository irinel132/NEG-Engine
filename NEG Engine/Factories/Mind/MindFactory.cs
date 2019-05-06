using NEG_Engine.Managers.Mind;
using NEG_Engine.Mind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories.Mind
{
    class MindFactory : AbstractFactory<IMind>, IMindFactory
    {
        #region Variables
        protected  IMindManager   _mindManager    = null;
        protected  int            _index          = 0;
        #endregion

        public MindFactory (IMindManager MindMngr)
        {
            _mindManager = MindMngr;
        }

        public IMind GetNewMind(Func<IMind> NewMind)
        {
            if (_mindManager == null) { return null; }

            Register(_index, NewMind);

            IMind mind = Create(_index++);

            _mindManager.AddMindToMindList(mind);

            return mind;
        }
    }
}
