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
using NEG_Engine.Managers.ManagerAdmin;
using NEG_Engine.Managers;

namespace NEG_Engine
{
    class Kernel
    {        
        // Public Variables
        public      bool                _gameRunning        = true;                     // If set to false, the thread will stop running
        // Internal Variables
        protected   Form                _gameWindow         = null;                     // The window of the game. Used for drawing
        protected   IGameThread         _gameThread         = null;                     // The game thread

        protected   IManagerAdmin       _managerAdmin       = null;                     // The admin of all the managers

        // DEBUG STUFF
        // TODO Move them to proper classes, to decluter Kernel
        protected IRender           _gameRender     = null;     // The game render
        protected ISpriteLoader     _spriteLoader   = null;     // The sprite loader        
        protected IWavLoader        _wavLoader      = null;     // THe sound loader

        // Constructor
        public Kernel (Form F)
        {
            this._gameWindow = F;                                                           // Assign the game window wo the proper variable            

            _gameRender = new BasicRender(_gameWindow, new Point(800, 600));                // Choose the game Window size
            _managerAdmin = new BasicManagerAdmin();                                        // Instantiate the Admin Manager

            // Calls the setup function of the kernel
            this.Setup();

            _gameThread = new GameThread(this); // Instantiante our GameThread. It will call upong Tick at GameThread.TICKS_PER_SECOND (default 60 ) ticks per seconds
            _gameThread.Start();                // Start the thread
        }
        
        
        // Methods
        protected void Setup()
        {

            ((IManager) _managerAdmin).Start(_managerAdmin);    // Cast the Admin Manager to a IManager and run the Start() method

            // DEBUG
            // Initialize and start the Sprite Loader
            // TODO Get rid of everything between the lines
            // ---------------------------START-----------------------------------------------------------------------------------|
            _spriteLoader   = new SpriteLoader();
            _wavLoader      = new WavLoader();

            ((Loader.IFileLoader) _spriteLoader).LoadFilesFromFolder("Bitmaps/", "*.bmp");
            ((Loader.IFileLoader) _wavLoader)   .LoadFilesFromFolder("Wavs/", "*.wav");           


            //-----------------------------END------------------------------------------------------------------------------------|
        }


        public void Tick (long Ticks)
        {
            ((IManager)_managerAdmin).Tick(Ticks);          // Cast the admin manager to IManager and run Tick()
        }


    }
}
