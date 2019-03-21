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
            EngineStart(Color.Purple, Screen.PrimaryScreen.Bounds, false);

        }

        public static Kernel EngineStart(Color BackColor, Rectangle Bounds, bool TopMost)
        {
            Form gameWindow = new Form();

            gameWindow.BackColor = BackColor;
            gameWindow.FormBorderStyle = FormBorderStyle.None;
            gameWindow.Bounds = Bounds;
            gameWindow.TopMost = TopMost;

            Application.EnableVisualStyles();
            Kernel NEGEngine = new Kernel(gameWindow);
            Application.Run(gameWindow);


            return NEGEngine;
        }
}
    }
}
