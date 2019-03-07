using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NEG_Engine;

namespace NEG_Engine.GThread
{
    interface IGameThread
    {
        void ThreadRun();

        Kernel GetKernel ();

        void Start ();
    }
}
