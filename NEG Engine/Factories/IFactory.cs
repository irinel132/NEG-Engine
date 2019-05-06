using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Factories
{
    interface IFactory <T>
    {
        T       Create      (int ID);

        void    Register    (int ID, Func<T> Ctor);
    }
}
