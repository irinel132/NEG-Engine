using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NEG_Engine.Loader
{
    abstract class FileLoader<T> : IFileLoader
    {
        // Internal variables
        protected List<T> _loadedFiles = null;      // Store all the loaded files here
        // Constructor
        public FileLoader()
        {
            _loadedFiles = new List<T>(); // Initialize the list
        }

        // Every class that inherits this will have to reimplement this 
        public abstract void LoadFile(string Path);

        // Interface Methods
        public void LoadFilesFromFolder(string Path, string FileType)
        {
            foreach (string path in Directory.EnumerateFiles(Path, FileType))
            {
                LoadFile(path);
            }
            
        }
    }
}
