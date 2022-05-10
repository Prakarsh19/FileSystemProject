using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    public delegate void Mydel(bool f);

    public delegate void Events(string msgs, bool f);
    public class FileVisitor
    {
        private string rootPath = @"C:\Temp";
        public event Events delEvent;

        private Mydel mydel;

        public FileVisitor()
        {
        }
        public FileVisitor(Mydel f)
        {
            mydel = f;
            mydel(true);
        }

        public void Files()
        {

            delEvent("Started Looking for files", true);

            foreach (string file in FindFiles())
            {
                string FileName = Path.GetFileName(file);
                delEvent(FileName, true);
            }
            delEvent("All files found Successfully", true);

        }
        public void CLLogger(string s, bool f)
        {
            if (f)
            {
                Console.WriteLine(s + "\n");
            }
            else
            {
                Console.WriteLine("Files Excluded......"+"\n");
            }
        }


        public void deleteFiles(bool f)
        {

            var folders = Directory.GetDirectories(rootPath);
            int fileCount = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories).Length;

            delEvent("Deleting files started..", true);



            if (fileCount == 0)
            {
                delEvent("No files found to delete", true);
                return;
            }



            foreach (var folder in folders)
            {
                var fs = Directory.GetFiles(folder);



                Console.WriteLine(folder + " ----------- files");
                foreach (string file in fs)
                {
                    
                    File.Delete(file);
                    delEvent(file, true);
                }
                Console.WriteLine("\n");



            }
            delEvent("Deleted all files", true);



        }
        public IEnumerable<string> FindFiles()
        {
            var files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
            var folders = Directory.GetDirectories(rootPath);
            foreach (var folder in folders)
            {
                var fs = Directory.GetFiles(folder);

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
