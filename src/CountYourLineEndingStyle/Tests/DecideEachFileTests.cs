using CountYourLineEndingStyle.Domain;
using FluentAssertions;
using Xunit;

namespace CountYourLineEndingStyle.Tests
{
    public class DecideEachFileTests
    {
        [Theory]
        [InlineData(LineEndings.Crlf, FileResult.Crlf)]
        [InlineData(LineEndings.Lf, FileResult.Lf)]
        public void TestJustOneLine(string lineEnding, FileResult expected)
        {
            FileResult fileResult = DecideEachFile.Perform(lineEnding);

            fileResult.Should().Be(expected);
        }

        [Theory]
        [InlineData(LineEndings.Crlf + "line " + LineEndings.Crlf, FileResult.Crlf)]
        [InlineData(LineEndings.Lf + "line " + LineEndings.Lf, FileResult.Lf)]
        public void TestMoreLines(string lineEnding, FileResult expected)
        {
            FileResult fileResult = DecideEachFile.Perform(lineEnding);

            fileResult.Should().Be(expected);
        }

        [Fact]
        public void Different_line_endings_should_return_mixed()
        {
            string content = LineEndings.Lf + "line " + LineEndings.Crlf;

            FileResult fileResult = DecideEachFile.Perform(content);

            fileResult.Should().Be(FileResult.Mixed);
        }
    }
}