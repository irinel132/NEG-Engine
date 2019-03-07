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
        protected Thread    _gameThread = null;

        // The thread that keeps the game running
        static void GameThread (Kernel Kernel)
        {
            // While the game is running
            while (Kernel._gameRunning)
            {
                SystemClock = DateTime.Now.Millisecond;             // Get the system time in MS                
                Ticks++;                                            // Intend the in engine time
                

                Kernel.Tick(Ticks);

                int sleepTime = (1000 / TICKS_PER_SECOND) - (SystemClock - DateTime.Now.Millisecond); // Maths doesn't need comments.
                Thread.Sleep(sleepTime);
            }
        }

        // Constructor
        public Kernel (Form F)
        {
            this._gameWindow = F;



            // Evil lambada. Could possibly do better 
            // TODO Fix The evil lambada
            this._gameThread = new Thread(() =>
            {
                Console.WriteLine("Threads");
                GameThread(this);                
            }
            );

            this._gameThread.Start();
        }


        // Methods
        public void Tick (long Ticks)
        {
            
        }


    }
}
