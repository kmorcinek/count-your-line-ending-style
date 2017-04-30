using System;
using System.Linq;
using CountYourLineEndingStyle.Domain;
using NDesk.Options;

namespace CountYourLineEndingStyle
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showHelp = false;
            string path = null;

            var p = new OptionSet {
                { "p|path=",
                    "path to repository folder",
                    v => path = v },
                { "h|help",  "show this message and exit",
                    v => showHelp = v != null },
            };

            try
            {
                p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `greet --help' for more information.");
                return;
            }

            if (string.IsNullOrEmpty(path))
            {
                showHelp = true;
            }

            if (showHelp)
            {
                ShowHelp(p);
                return;
            }

            var statistics = Manager.Run(path);

            foreach (var result in statistics.Results.Where(x => x.Is(FileResult.Lf)))
            {
                Console.WriteLine($"LF path: {result.Path}");
            }

            foreach (var result in statistics.Results.Where(x => x.Is(FileResult.Mixed)))
            {
                Console.WriteLine($"Mixed path: {result.Path}");
            }

            Console.WriteLine($"Crlf: {statistics.Crlf}");
            Console.WriteLine($"Lf: {statistics.Lf}");
            Console.WriteLine($"Mixed: {statistics.Mixed}");
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Use: CountYourLineEndingsStyle -p C:/SRC/YourProject");
            Console.WriteLine("Count what Line Ending have your *.cs files.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}
