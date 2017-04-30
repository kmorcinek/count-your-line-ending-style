using System;
using System.Collections.Generic;
using System.Linq;
using CountYourLineEndingStyle.Domain.Results;

namespace CountYourLineEndingStyle.Domain
{
    public class Manager
    {
        public static Statistics Run()
        {
            IEnumerable<string> files = FilesRetriever.GetFiles("");

            IEnumerable<Result> enumerable = files.Select(Selector).ToList();

            return new Statistics
            {
                Crlf = enumerable.Count(x => x.Is(FileResult.Crlf)),
                Lf = enumerable.Count(x => x.Is(FileResult.Lf)),
                Mixed = enumerable.Count(x => x.Is(FileResult.Mixed))
            };
        }

        static Result Selector(string path)
        {
            return new SkipResult(path);
        }
    }
}