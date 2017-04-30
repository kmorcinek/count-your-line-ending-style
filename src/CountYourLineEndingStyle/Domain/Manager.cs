using System;
using System.Collections.Generic;
using System.Linq;
using CountYourLineEndingStyle.Domain.Results;

namespace CountYourLineEndingStyle.Domain
{
    public class Manager
    {
        public static void Run()
        {
            IEnumerable<string> files = FilesRetriever.GetFiles("");

            IEnumerable<Result> enumerable = files.Select(Selector);

            int crlfCount = enumerable.Count(x => x.Is(FileResult.Crlf));

            Console.WriteLine($"crlf: {crlfCount}");
        }

        static Result Selector(string path)
        {
            return new SkipResult(path);
        }
    }
}