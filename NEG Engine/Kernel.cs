using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using NEG_Engine.GThread;
using NEG_Engine.Render;
using System.Drawing;
using NEG_Engine.Loader.Sprite;
using NEG_Engine.WavPlayer;
using NEG_Engine.Loader.Wav;

namespace NEG_Engine
{
    class Kernel
    {        
        // Public Variables
        public bool     _gameRunning = true;                    // If set to false, the thread will stop running
        // Internal Variables
        protected Form              _gameWindow = null;         // The window of the game. Used for drawing
        protected IGameThread       _gameThread = null;         // The game thread

        // DEBUG STUFF
        // TODO Move them to proper classes, to decluter Kernel
        protected IRender           _gameRender     = null;     // The game render
        protected ISpriteLoader     _spriteLoader   = null;     // The sprite loader        
        protected IWavLoader        _wavLoader      = null;     // THe sound loader

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
            // Choose the game Window size
            _gameRender = new BasicRender(_gameWindow, new Point(800, 600));

            // DEBUG
            // Initialize and start the Sprite Loader
            _spriteLoader   = new SpriteLoader();
            _wavLoader      = new WavLoader();

            ((Loader.IFileLoader) _spriteLoader).LoadFilesFromFolder("Bitmaps/", "*.bmp");
            ((Loader.IFileLoader) _wavLoader)   .LoadFilesFromFolder("Wavs/", "*.wav");

            _wavLoader.GetWav(0).Play();

        }


        public void Tick (long Ticks)
        {            

        }


    }
}
