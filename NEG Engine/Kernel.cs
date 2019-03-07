using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace NEG_Engine
{
    class Kernel
    {
        // Static variables
        public readonly static int              TICKS_PER_SECOND    = 60;       // Determines how many logic and graphics cycles happen per second
        public          static long             Ticks               = 0;        // Used for measuring In engine time
        public          static int              SystemClock         = 0;        // Ties the in engine time with the real system clock
        // Public Variables
        public bool     _gameRunning = true;                    // If set to false, the thread will stop running
        // Internal Variables
        protected Form      _gameWindow = null;

        // The thread that keeps the game running
        protected void GameThread ()
        {
            // While the game is running
            while (this._gameRunning)
            {
                SystemClock = DateTime.Now.Millisecond;             // Get the system time in MS                
                Ticks++;                                            // Intend the in engine time
                

                this.Tick(Ticks);

                int sleepTime = (1000 / TICKS_PER_SECOND) - (SystemClock - DateTime.Now.Millisecond); // Maths doesn't need comments.
                Thread.Sleep(sleepTime);
            }
        }

        // Constructor
        public Kernel (Form F)
        {
            this._gameWindow = F;



            GameThread();
        }


        // Methods
        public void Tick (long Ticks)
        {
            Console.WriteLine("Hello " + Ticks.ToString());
        }


    }
}
