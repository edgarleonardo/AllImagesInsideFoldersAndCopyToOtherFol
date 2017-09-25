
using System.Configuration;
using System.IO;

namespace AllImagesInsideFoldersAndCopyToOtherFol
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "\\\\win-9lck90b4hfi\\ArtsPathPR";
            ProcessDirectory(path);
        }

        
        public static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }
            
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory);
            }
        }
        
        public static void ProcessFile(string path)
        {
            var Files = new FileInfo(path);
            var filename = Files.Name;
            System.IO.File.Copy(path, ConfigurationManager.AppSettings["URL_LOCAL"].ToString()+"\\"+ Files.Name, true);
        }
    }
}
