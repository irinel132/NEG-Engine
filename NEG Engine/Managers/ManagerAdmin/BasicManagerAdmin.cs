using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.ManagerAdmin
{
    class BasicManagerAdmin : IManagerAdmin
    {
        // Internal variables
        protected   List<IManager>      _managerList        = null;     // Will hold all the managers

        // Constructors
        public BasicManagerAdmin ()
        {
            _managerList = new List<IManager>();    // Instantiate the list
        }

        // Interface methods
        public bool AddToManagerList(IManager NewManager)
        {
            int oldLength = _managerList.Count;                 // Check the length before adding

             _managerList.Add(NewManager);                      // Add the manager to the list

            return ((_managerList.Count - oldLength) > 0);      // Return true if the count has increased (if the manager was added)
        }

        public IManager GetManager(int Index)
        {
            throw new NotImplementedException();
        }

        public IManager GetManager(string ManagerTag)
        {
            throw new NotImplementedException();
        }

        public bool RemoveManagerFromList(int Index)
        {
            throw new NotImplementedException();
        }

        public bool RemoveManagerFromList(string ManagerTag)
        {
            throw new NotImplementedException();
        }

        // Methods
    }
}
