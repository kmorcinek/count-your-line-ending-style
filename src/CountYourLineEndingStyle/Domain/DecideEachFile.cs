namespace CountYourLineEndingStyle.Domain
{
    public class DecideEachFile
    {
        public static FileResult Perform(string content)
        {
            if (content == LineEndings.Lf)
            {
                return FileResult.Lf;
            }

            return FileResult.Crlf;
        }
    }
}