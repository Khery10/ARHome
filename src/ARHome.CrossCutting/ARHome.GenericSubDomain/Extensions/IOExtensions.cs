using System.IO;
using ARHome.GenericSubDomain.Exceptions;

namespace ARHome.GenericSubDomain.Extensions
{
    public static class IOExtensions
    {
        public static FileInfo GetFileInfo(this DirectoryInfo directory, string pattern)
        {
            var files = directory.GetFiles(pattern);

            if (files.Length == 0)
                throw new FileNotFoundException($"Could not find file by pattern {pattern}");

            if (files.Length > 1)
                throw new ARHomeException($"Multiple files found by pattern {pattern}");

            return files[0];
        }
    }
}