using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileSystemVisitor = new FileVisitor();
            var notifications = new Notifications();
            fileSystemVisitor.FileSearchStart += notifications.OnStartSearch;
            fileSystemVisitor.FileSearchEnd += notifications.OnCompleteSearch;
            fileSystemVisitor.FileFound += notifications.OnFind;
            fileSystemVisitor.FileAbort += notifications.OnAbort;
            fileSystemVisitor.FileDeleteStart += notifications.OnDeleteStart;
            fileSystemVisitor.FileDeleted += notifications.OnDeletion;
            fileSystemVisitor.FileDeleteEnd += notifications.OnDeleteComplete;
            // new FileSystemRoot(@"C:\Temp", "FileToSearch", "FileTobeDeleted","FileTobeExcluded", AbortCase);
            var fileSystemroots = new FileSystemRoot(@"C:\Temp", "File2_1", "File2_1",".py", true);
            fileSystemVisitor.FileSearch(fileSystemroots);
            new FileVisitor(fileSystemVisitor.deleteFiles, fileSystemroots);
            Console.ReadLine();
        }
    }
}
