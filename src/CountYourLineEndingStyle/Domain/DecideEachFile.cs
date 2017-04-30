using System;

namespace CountYourLineEndingStyle.Domain
{
    public class DecideEachFile
    {
        public static FileResult Perform(string content)
        {
            // Count number of \r\n
            // Count number of \n
            // compare
            int lfLinesCount = content.Length - content.Replace(LineEndings.Lf, string.Empty).Length;

            //int numLines = content.Split('\n').Length;

            if (content == LineEndings.Lf)
            {
                return FileResult.Lf;
            }

            return FileResult.Crlf;
        }
    }
}