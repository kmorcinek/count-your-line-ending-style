using System.Collections.Generic;
using System.IO;

namespace CountYourLineEndingStyle.Domain
{
    public class FilesRetriever
    {
        public static IEnumerable<string> GetFiles(string basePath)
        {
            return Directory.EnumerateFiles(basePath, "*.cs", SearchOption.AllDirectories);
        }
    }
}