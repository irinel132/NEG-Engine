using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NEG_Engine.Loader
{
    interface IFileLoader
    {
        // Load all of the FileType type files in the Location folder
        void LoadFilesFromFolder(string Location, string FileType);

        // Will load one file to the _loadedFiles
        void LoadFile(string path);
    }
}
