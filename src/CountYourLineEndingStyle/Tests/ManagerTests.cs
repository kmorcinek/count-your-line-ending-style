using System;
using System.IO;
using CountYourLineEndingStyle.Domain;
using FluentAssertions;
using Xunit;

namespace CountYourLineEndingStyle.Tests
{
    public class ManagerTests : IDisposable
    {
        const string BasePath = @"ManagerTest";

        public ManagerTests()
        {
            Directory.CreateDirectory(BasePath);
        }

        [Fact]
        public void Check_one_folder()
        {
            RecreateFile("a.cs", LineEndings.Crlf);
            RecreateFile("b.cs", LineEndings.Crlf);
            RecreateFile("c.cs", LineEndings.Lf);
            RecreateFile("d.cs", LineEndings.Lf + LineEndings.Crlf);

            var statistics = Manager.Run(BasePath);

            statistics.Crlf.Should().Be(2);
            statistics.Lf.Should().Be(1);
            statistics.Mixed.Should().Be(1);
        }

        [Fact]
        public void Check_recursive_folder()
        {
            string innerFolder = Path.Combine(BasePath, "inner");
            Directory.CreateDirectory(innerFolder);

            RecreateFile("a.cs", LineEndings.Crlf);
            RecreateFile(@"inner\b.cs", LineEndings.Crlf);

            var statistics = Manager.Run(BasePath);

            statistics.Crlf.Should().Be(2);
            statistics.Lf.Should().Be(0);
            statistics.Mixed.Should().Be(0);
        }

        static void RecreateFile(string fileName, string content)
        {
            var path = Path.Combine(BasePath, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, content);
        }

        public void Dispose()
        {
            Directory.Delete(BasePath, true);
        }
    }
}