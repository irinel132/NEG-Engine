using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace NEG_Engine.GThread
{
    class GameThread : IGameThread
    {
        // Static variables
        public readonly static int TICKS_PER_SECOND = 60;       // Determines how many logic and graphics cycles happen per second

        public static long  Ticks = 0;              // Used for measuring In engine time
        public static int   SystemClock = 0;        // Ties the in engine time with the real system clock

        
        
        // Internal variables
        protected Thread _thread    = null;         // The thread used for keeping the game running
        protected Kernel _kernel    = null;         // The main kernel



        // Constructor
        public GameThread (Kernel Kernel)
        {
            _kernel = Kernel;   // Assign the kernel to the local variable
            _thread = new Thread(ThreadRun);    // Create the thread and tell it what to run
        }

        // Simply returns the kernel
        public Kernel GetKernel()
        {
            return _kernel;
        }

        // Starts the thread
        public void Start()
        {
            _thread.Start();
        }

        // If the game is running, it will call Kernel.Tick() at a rate of TICKS_PER_SECOND per second
        public void ThreadRun ()
        {
            // While the game is running
            while (_kernel._gameRunning)
            {
                SystemClock = DateTime.Now.Millisecond;             // Get the system time in MS                
                Ticks++;                                            // Intend the in engine time


                _kernel.Tick(Ticks);    // The promised call

                int sleepTime = (1000 / TICKS_PER_SECOND) - (SystemClock - DateTime.Now.Millisecond); // Maths doesn't need comments.
                Thread.Sleep(sleepTime);
            }
        }
    }
}
