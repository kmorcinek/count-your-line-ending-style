using CountYourLineEndingStyle.Domain.Results;

namespace CountYourLineEndingStyle.Domain
{
    public class Statistics
    {
        public int Crlf { get; set; }
        public int Lf { get; set; }
        public int Mixed { get; set; }
        public Result[] Results { get; set; }
    }
}