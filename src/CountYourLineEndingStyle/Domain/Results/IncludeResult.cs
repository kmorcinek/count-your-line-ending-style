namespace CountYourLineEndingStyle.Domain.Results
{
    public class IncludeResult : Result
    {
        readonly FileResult _fileResult;

        public IncludeResult(string path, FileResult fileResult) : base(path)
        {
            _fileResult = fileResult;
        }

        public override bool Is(FileResult fileResult)
        {
            return _fileResult == fileResult;
        }
    }
}