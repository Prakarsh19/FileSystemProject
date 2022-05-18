using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    public class Notifications
    {
        public Notifications()
        {
            
        }
        public void OnStartSearch(object sender, FileSystemRoot fileSystemRoot)
        {
            Console.WriteLine("File Search Started -------");
            Console.WriteLine();
        }
        public void OnCompleteSearch(object sender, FileSystemRoot fileSystemRoot)
        {
            Console.WriteLine("File Search Completed ------");
            Console.WriteLine();
        }
        public void OnFind(object sender, FileSystemRoot fileSystemRoot)
        {
            Console.WriteLine($"File found in ...{fileSystemRoot.Path}");
            Console.WriteLine();
        }
        public void OnDeleteStart(object sender, FileSystemRoot fileSystemRoot)
        {
            Console.WriteLine("File Deletion Started -------");
            Console.WriteLine();
        }
        public void OnDeletion(object sender, FileSystemRoot fileSystemRoot)
        {
            Console.WriteLine($"File deleted from ...{fileSystemRoot.Path}");
            Console.WriteLine();
        }
        public void OnDeleteComplete(object sender, FileSystemRoot fileSystemRoot)
        {
            Console.WriteLine("File Deletion Completed ------");
            Console.WriteLine();
        }
        public void OnAbort(object sender, FileSystemRoot fileSystemRoot)
        {
            Console.WriteLine("File Search Has Been Aborted");
        }
    }
}
