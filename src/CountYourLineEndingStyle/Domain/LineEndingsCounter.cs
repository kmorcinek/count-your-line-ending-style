namespace CountYourLineEndingStyle.Domain
{
    public class LineEndingsCounter
    {
        public static int CountCrlf(string content)
        {
            int crlfLinesCount = content.Length - content.Replace(LineEndings.Crlf, string.Empty).Length;
            // In case of CRLF cause it takes two characters
            crlfLinesCount /= 2;

            return crlfLinesCount;
        }

        public static int CountOnlyLf(string content)
        {
            return CountLf(content) - CountCrlf(content);
        }
            
        static int CountLf(string content)
        {
            int lfLinesCount = content.Length - content.Replace(LineEndings.Lf, string.Empty).Length;

            return lfLinesCount;
        }
    }
}