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
            FileVisitor fileVisitor = new FileVisitor();
            fileVisitor.delEvent += new Events(fileVisitor.CLLogger);
            fileVisitor.Files();
            new FileVisitor(fileVisitor.deleteFiles);
            Console.ReadLine();
        }
    }
}
