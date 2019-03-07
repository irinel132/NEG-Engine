using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using NEG_Engine.GThread;
using NEG_Engine.Render;

namespace NEG_Engine
{
    class Kernel
    {        
        // Public Variables
        public bool     _gameRunning = true;                    // If set to false, the thread will stop running
        // Internal Variables
        protected Form              _gameWindow = null;         // The window of the game. Used for drawing
        protected IGameThread       _gameThread = null;         // The game thread
        protected IRender           _gameRender = null;         // The game render
        

        // The thread that keeps the game running
        static void GameThread (Kernel Kernel)
        {
                        
        }

        // Constructor
        public Kernel (Form F)
        {
            this._gameWindow = F;               // Assign the game window wo the proper variable

            this.Setup();

            _gameThread = new GameThread(this); // Instantiante our GameThread. It will call upong Tick at GameThread.TICKS_PER_SECOND (default 60 ) ticks per seconds
            _gameThread.Start();                // Start the thread
        }
        

        // Methods
        protected void Setup()
        {
            _gameRender = new BasicRender(_gameWindow);
        }
        public void Tick (long Ticks)
        {
            
        }


    }
}
