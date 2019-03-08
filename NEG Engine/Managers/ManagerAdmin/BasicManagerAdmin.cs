using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Managers.ManagerAdmin
{
    class BasicManagerAdmin : IManagerAdmin, IManager, IDisposable
    {
        // Internal variables
        protected   List<IManager>      _managerList        = null;     // Will hold all the managers

        // Constructors
        public BasicManagerAdmin ()
        {
            _managerList = new List<IManager>();                        // Instantiate the list
        }

        // Interface methods
        public bool AddToManagerList(IManager NewManager)
        {
            int oldLength = _managerList.Count;                 // Check the length before adding

             _managerList.Add(NewManager);                      // Add the manager to the list

            return ((_managerList.Count - oldLength) > 0);      // Return true if the count has increased (if the manager was added)
        }

        public void Dispose()
        {
            _managerList = null;
        }

        //
        public void End()
        {
            foreach (IManager manager in _managerList)  // Loop every manager
            {
                manager.End();          // End every manager
            }

            Dispose();
        }


        // Returns a manager using the Index
        public IManager GetManager(int Index)
        {
            return _managerList[Index];
        }


        // Returns a manager using a  ManagerTag string
        public IManager GetManager(string ManagerTag) 
        {
            foreach (IManager manager in _managerList)
            {
                if (manager.GetManagerTag().ToUpper() == ManagerTag.ToUpper())      // If the strings match
                    return manager;                                                 // Return the manager and exit the methods
            }

            return null;                                                            // If nothing was found, return a null object
        }


        // Return the ManagerTag of the class
        public string GetManagerTag()
        {
            return "MANAGER_ADMIN";  // The tag for the manager
        }



        // Removes a manager from list using a Index to remove it
        public bool RemoveManagerFromList(int Index)
        {
            int oldLength = _managerList.Count;                 // Check the length before adding

            _managerList.RemoveAt(Index);                       // remove the manager from the list

            return !((_managerList.Count - oldLength) > 0);     // Return true if the count has decreased (if the manager was removed)
        }


        // Removes a manager from list using a ManagerTag to identify it
        public bool RemoveManagerFromList(string ManagerTag)
        {
            int oldLength = _managerList.Count;                 // Check the length before adding

            foreach (IManager manager in _managerList)
            {
                if (manager.GetManagerTag().ToUpper() == ManagerTag.ToUpper())      // If the strings match
                {
                    _managerList.Remove(manager);                                   // Remove the manager from the manager list
                    break;                                                          // Break the loop
                }
            }

            return !((_managerList.Count - oldLength) > 0);     // Return true if the count has decreased (if the manager was removed)
        }

        public void Start(IManagerAdmin ManagerAdmin)
        {
            foreach (IManager manager in _managerList)      // Loop every manager
            {
                manager.Start(this);                        // Calls the start method of every manager
            }
        }

        // Calls the tick method of every manager in list
        public void Tick(long Ticks)
        {            
            foreach (IManager manager in _managerList)      // Loop every IManager
            {
                manager.Tick(Ticks);                        // Call the tick method
            }
        }

        // Methods
    }
}
