using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories
{
    public class AbstractFactory<T>: IFactory<T>
    {
        protected Dictionary<int, Func<T>> _newInstances
             = new Dictionary<int, Func<T>>();      // Holds a list of new entities

        protected AbstractFactory ()
        {
            _newInstances = new Dictionary<int, Func<T>>();
        }

        // Actually stores a constructor for a class and registers it to the id.
        public T Create(int id)
        {
            Func<T> constructor = null;
            if (_newInstances.TryGetValue(id, out constructor))
                return constructor();

            throw new ArgumentException("No type registered for this id");
        }

        // Uses a lambda to register new constructors to instantiate when Create is called
        public void Register(int id, Func<T> ctor)
        {
            _newInstances.Add(id, ctor);
        }
    }
}
