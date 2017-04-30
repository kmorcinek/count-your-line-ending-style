namespace CountYourLineEndingStyle.Domain.Results
{
    public abstract class Result
    {
        protected Result(string path)
        {
            Path = path;
        }

        public string Path { get; }

        public abstract bool Is(FileResult fileResult);
    }
}