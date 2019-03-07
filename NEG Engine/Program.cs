using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Drawing;

namespace NEG_Engine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form gameWindow = new Form();

            gameWindow.BackColor        = Color.White;
            gameWindow.FormBorderStyle  = FormBorderStyle.None;
            gameWindow.Bounds           = Screen.PrimaryScreen.Bounds;
            gameWindow.TopMost          = false;

            Application.EnableVisualStyles();
            new Kernel(gameWindow);
            Application.Run(gameWindow);

            

            
        }
    }
}
