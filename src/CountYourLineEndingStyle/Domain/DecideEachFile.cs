namespace CountYourLineEndingStyle.Domain
{
    public class DecideEachFile
    {
        public static FileResult Perform(string content)
        {
            return FileResult.Crlf;
        }
    }
}