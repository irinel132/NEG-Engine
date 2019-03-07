using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace NEG_Engine.Loader.Wav
{
    class WavLoader : FileLoader<SoundPlayer>, IWavLoader, IFileLoader
    {
        // Returns a bitmap using the provided Index
        public SoundPlayer GetWav(int Index)
        {
            return this._loadedFiles[Index];
        }

        // Loads the file with the path provided into _loadedFiles
        public override void LoadFile(string Path)
        {
            this._loadedFiles.Add(new SoundPlayer(Path));
        }
    }
}
