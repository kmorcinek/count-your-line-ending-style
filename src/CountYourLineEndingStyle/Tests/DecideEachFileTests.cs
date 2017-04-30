using CountYourLineEndingStyle.Domain;
using FluentAssertions;
using Xunit;

namespace CountYourLineEndingStyle.Tests
{
    public class DecideEachFileTests
    {
        [Theory]
        [InlineData("\r\n", FileResult.Crlf)]
        [InlineData("\n", FileResult.Lf)]
        public void TestJustOneLine(string lineEnding, FileResult expected)
        {
            FileResult fileResult = DecideEachFile.Perform(lineEnding);

            fileResult.Should().Be(expected);
        }
    }
}