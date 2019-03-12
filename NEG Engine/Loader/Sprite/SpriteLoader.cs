using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.IO;

namespace NEG_Engine.Loader.Sprite
{
    class SpriteLoader : FileLoader<Bitmap>, ISpriteLoader, IFileLoader
    {
        // Constructor
        public SpriteLoader ()
        {
            LoadFilesFromFolder("Bitmaps/", "*.bmp");       // Load all the .bmp files from the Bitmaps/ folder
        }


        // Returns a bitmap using the provided Index
        public Bitmap GetBitmap(int Index)
        {
            return _loadedFiles[Index];
        }

        // Loads the file with the path provided into _loadedFiles
        public override void LoadFile(string path)
        {
            this._loadedFiles.Add(new Bitmap(path));
        }
    }
}

