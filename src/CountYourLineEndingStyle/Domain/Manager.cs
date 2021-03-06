﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using CountYourLineEndingStyle.Domain.Results;

namespace CountYourLineEndingStyle.Domain
{
    public class Manager
    {
        public static Statistics Run(string basePath)
        {
            IEnumerable<string> files = FilesRetriever.GetFiles(basePath);

            Result[] enumerable = files.Select(Selector).ToArray();

            return new Statistics
            {
                Crlf = enumerable.Count(x => x.Is(FileResult.Crlf)),
                Lf = enumerable.Count(x => x.Is(FileResult.Lf)),
                Mixed = enumerable.Count(x => x.Is(FileResult.Mixed)),
                Results = enumerable
            };
        }

        static Result Selector(string path)
        {
            var content = File.ReadAllText(path);

            var result = new IncludeResult(path, DecideEachFile.Perform(content));

            return result;
        }
    }
}