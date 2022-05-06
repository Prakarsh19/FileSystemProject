using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemProject
{
    public class FileVisitor
    {
        public delegate string MyDel(string str);
        public event MyDel MyEvent;
        private string rootPath = @"C:\Temp";
        public FileVisitor()
        {
            
            Notification("Start of Search");
            foreach (string file in FindFiles())
            {
                Console.WriteLine(file);
            };
            Notification("End of Search");
        }

        public FileVisitor(bool flag)
        {
            Notification("Deleting Files ...");
            string[] files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
            Array.ForEach(files, file => File.Delete(file)) ;
            Notification("Files Deleted Successfully");
        }
      

        public IEnumerable<string> FindFiles()
        {
            var files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                yield return file;

            }
        }
        private void Notification(string Event)
        {
            MyEvent += new MyDel(Notify);
            string result = MyEvent(Event);
            Console.WriteLine(result);
        }
        private string Notify(string action)
        {
            return  action;
        }
    }
}
