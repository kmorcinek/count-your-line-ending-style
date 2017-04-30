namespace CountYourLineEndingStyle.Domain.Results
{
    public class SkipResult : Result
    {
        public SkipResult(string path) : base(path)
        {
        }

        public override bool Is(FileResult fileResult)
        {
            return false;
        }
    }
}