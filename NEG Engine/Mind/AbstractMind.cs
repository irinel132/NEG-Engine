using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NEG_Engine.Managers.Mind;

namespace NEG_Engine.Mind
{
    abstract class AbstractMind : IMind
    {
        #region Variables
        public static string MIND_TAG = "DEFAULT";
        // Internal variables
        protected   IMindManager  _mindManager = null;  // Reference to the mind manager        

        public string GetMindTag()
        {
            return MIND_TAG;
        }
        #endregion

        #region Interface methods

        public void Setup(IMindManager MindManager)
        {
            _mindManager = MindManager; // Store the mind manager in the internal variable
        }

        public abstract void Tick(long Tick);

        #endregion
    }
}
