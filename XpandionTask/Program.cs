using System;
using System.Configuration;
using System.IO;

namespace XpandionTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["path"];
            string[] subDir = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

            if (subDir.Length > 0)
                RunDirectory(subDir);
            else
                Console.WriteLine("there is no subfolders in path");
        }

        static void RunDirectory(string[] subDir)
        {
            foreach (var dir in subDir)
            {
                string[] files = Directory.GetFiles(dir);
                int fileCount = files.Length;
                long filesSize = 0;
                
                foreach (string file in files)
                { 
                    FileInfo fileInfo = new FileInfo(file);
                    filesSize += fileInfo.Length;
                }

                Console.WriteLine("the path: {0}, include: {1} files AND total size of: {2} bytes", dir, fileCount, filesSize);
            }
        }
    }
}
