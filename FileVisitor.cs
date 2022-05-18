using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    
    public delegate void Mydel(FileSystemRoot fileSystemRoot);
    public class FileVisitor
    {
        public event EventHandler<FileSystemRoot> FileSearchStart;
        public event EventHandler<FileSystemRoot> FileSearchEnd;
        public event EventHandler<FileSystemRoot> FileAbort;
        public event EventHandler<FileSystemRoot> FileFound;
        public event EventHandler<FileSystemRoot> FileDeleteStart;
        public event EventHandler<FileSystemRoot> FileDeleteEnd;
        public event EventHandler<FileSystemRoot> FileDeleted;
        public FileVisitor()
        {
        }
        
        public void FileSearch(FileSystemRoot fileSystemRoot)
        {
            
            try
            {
                string path,fileNameExtension;
                path = fileSystemRoot.Path;
                FileSearchStart?.Invoke(this, fileSystemRoot);
                foreach (string file in FindFiles(fileSystemRoot))
                {
                    fileNameExtension = Path.GetExtension(file);
                    if(fileSystemRoot.AbortFile && string.IsNullOrWhiteSpace(fileNameExtension))
                    {
                        FileAbort?.Invoke(this, fileSystemRoot);
                        return;
                    }
                    string FileName = Path.GetFileName(file);
                    if (file.Contains(fileSystemRoot.SearchFileName))
                    {
                        FileFound?.Invoke(this, fileSystemRoot);
                    }
                    Console.WriteLine(file);
                }
                FileSearchEnd?.Invoke(this, fileSystemRoot);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
        }
        private Mydel mydel;
        public FileVisitor(Mydel f, FileSystemRoot fileSystemRoot)
        {
            mydel = f;
            mydel(fileSystemRoot);
        }

        public void deleteFiles(FileSystemRoot fileSystemRoot)
        {

            var folders = Directory.GetDirectories(fileSystemRoot.Path);
            int fileCount = Directory.GetFiles(fileSystemRoot.Path, "*.*", SearchOption.AllDirectories).Length;
            if (fileCount == 0)
            {
                FileAbort?.Invoke(this, fileSystemRoot);
                return;
            }
            FileDeleteStart?.Invoke(this, fileSystemRoot);
            foreach (var folder in folders)
            {
                var fs = Directory.GetFiles(folder);
                
                foreach (string file in fs)
                {
                    var fileNameExtension = Path.GetExtension(file);
                    if (file.Contains(fileSystemRoot.DeleteFileName))
                    {
                        File.Delete(file);
                        FileDeleted?.Invoke(this, fileSystemRoot);
                    }
                }
            }
            FileDeleteEnd?.Invoke(this, fileSystemRoot);
        }
        public IEnumerable<string> FindFiles(FileSystemRoot fileSystemRoot)
                {
                    var files = Directory.GetFiles(fileSystemRoot.Path, "*", SearchOption.AllDirectories);
                    var folders = Directory.GetDirectories(fileSystemRoot.Path);
                    foreach (var folder in folders)
                    {
                        var fs = Directory.GetFiles(folder).Where(excludeFiles=>!excludeFiles.EndsWith(fileSystemRoot.FilesToExclude));
                        Console.WriteLine(folder + " ----------- files");
                        foreach (string file in fs)
                        {
                            yield return file;
                        }
                        Console.WriteLine("\n");
                    }
                }

    }
}
