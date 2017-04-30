namespace CountYourLineEndingStyle.Domain
{
    public class DecideEachFile
    {
        public static FileResult Perform(string content)
        {
            // Count number of \r\n
            int crlfLinesCount = LineEndingsCounter.CountCrlf(content);

            // Count number of \n
            int lfLinesCount = LineEndingsCounter.CountOnlyLf(content);

            // compare
            if (crlfLinesCount > 0)
            {
                if (lfLinesCount > 0)
                {
                    return FileResult.Mixed;
                }

                return FileResult.Crlf;
            }

            if (lfLinesCount > 0)
            {
                return FileResult.Lf;
            }

            return FileResult.NoApply;
        }
    }
}