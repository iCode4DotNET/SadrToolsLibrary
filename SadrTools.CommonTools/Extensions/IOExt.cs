using System.Collections.Generic;
using System.IO;

namespace SadrTools.Extensions
{
    public static class IOExt
    {
        public static List<string> GetInfo(this IEnumerable<FileInfo> files)
        {
            var result = new List<string>();

            foreach (FileInfo item in files)
            {
                result.Add($"{item.Name.PadRight(200)}\t{item.Length.ToString().PadRight(20)} B\t{(item.Length / 1024).ToString().PadRight(20)} KB\t{((item.Length / 1024) / 1024).ToString().PadRight(20)} MB\n");
            }

            return result;
        }
    }

}
