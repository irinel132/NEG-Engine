using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.IO;

namespace NEG_Engine.Loader.Sprite
{
    class SpriteLoader : ISpriteLoader, IDisposable
    {
        // Internal Variables
        protected List<Bitmap>     _bitmapArray = null;


        // Constructors
        public SpriteLoader ()
        {
            _bitmapArray = new List<Bitmap>();
        }


        // Methods

            // Will empty any memory in use
        public void Dispose()
        {
            _bitmapArray = null;
        }

        // Return the bitmap using hte provided Index
        public Bitmap GetBitmap(int Index)
        {
            return _bitmapArray[Index];
        }

        // Loads all the images from the Bitmaps folder
        public void LoadImages()
        {
            
            foreach (string path in Directory.EnumerateFiles("Bitmaps/", "*.bmp"))
            {
                Console.WriteLine(path);

                _bitmapArray.Add(new Bitmap(path));
            }
        }
    }
}
