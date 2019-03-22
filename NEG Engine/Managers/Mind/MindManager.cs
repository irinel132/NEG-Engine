using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NEG_Engine.Managers.ManagerAdmin;
using NEG_Engine.Mind;

namespace NEG_Engine.Managers.Mind
{
    class MindManager : IMindManager, IManager, IDisposable
    {
        #region Variables
        public static readonly string       MANAGER_TAG     = "MindManager";
        protected   List<IMind>             _mindList       = null;         // The list of all the minds        

        #endregion

        public MindManager()
        {            
        }

        #region Inerited methods

        public bool AddMindToMindList(IMind Mind)
        {
            int initialCount = _mindList.Count;       // Check the size of the render list 

            _mindList.Add(Mind);

            // Returns true if the sprite was removed to the render list
            return ((_mindList.Count - initialCount) == 0);
        }

        public void Dispose()
        {
            _mindList = null;
        }

        public void End()
        {
            Dispose();
        }

        public IMind[] FindMind(string MindTag)
        {
            List<IMind> minds = new List<IMind>();

            foreach (IMind mind in _mindList)
            {
                if (mind.GetMindTag().ToUpper() == MindTag.ToUpper())
                    minds.Add(mind);
            }

            return minds.ToArray();
        }

        public string GetManagerTag()
        {
            return MANAGER_TAG;
        }

        public bool RemoveMindFromList(IMind Mind)
        {
            int initialCount = _mindList.Count;       // Check the size of the render list 

            _mindList.Remove(Mind);

            return ((_mindList.Count - initialCount) == 0);
        }

        public bool RemoveMindFromList(int Index)
        {
            int initialCount = _mindList.Count;       // Check the size of the render list 

            _mindList.RemoveAt(Index);

            return ((_mindList.Count - initialCount) == 0);
        }

        public void Start(IManagerAdmin ManagerAdmin)
        {
            _mindList = new List<IMind>();

            Factories.Mind.MindFactory.SetMindManager(this);
        }

        public void Tick(long Ticks)
        {
            foreach (IMind mind in _mindList)
            {
                mind.Tick(Ticks);
            }
        }

        #endregion

        #region Methods


        #endregion

    }
}
