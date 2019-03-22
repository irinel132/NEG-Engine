using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEG_Engine.Input
{
    class InputHandler
    {
        #region Variables
        protected   Form                    _gameWindow         = null;                     // The window of the game. Used for keyboard input
        protected   List<IInputListener>    _inputListeners     = null;

        #endregion

        InputHandler()
        {
            _inputListeners = new List<IInputListener>();
        }


        #region Singleton logic

        private static InputHandler     _instance   = null;
        private static readonly object  _padlock    = new object();        

        public static InputHandler Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new InputHandler();
                    }
                    return _instance;
                }
            }
        }

        #endregion


        #region Methods 

        public void SetGameWindow (ref Form GameWindow)
        {
            _gameWindow = GameWindow;
        }

        public void Subscribe(IInputListener InputListener)
        {
            _gameWindow.KeyPreview = true;

            _gameWindow.KeyDown += InputListener.KeyDown;
        }
        #endregion
    }
}
