using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    public class FileSystemRoot
    {
        public string Path { get; private set; }
        public string SearchFileName { get; private set; }
        public string DeleteFileName { get; private set; }
        public string FilesToExclude { get; private set; }
        public bool AbortFile { get;  set; }
        public FileSystemRoot(string path, string s,string d,string ex, bool abortFile)
        {
            Path = path;
            SearchFileName = s;
            DeleteFileName = d;
            FilesToExclude = ex;
            AbortFile = abortFile;
        }

    }
}
