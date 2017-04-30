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

        //[Theory]
//        [InlineData(LineEndings.Crlf + "line " + LineEndings.Crlf, FileResult.Crlf)]
//        [InlineData(LineEndings.Lf + "line " + LineEndings.Lf, FileResult.Lf)]
        public void TestMoreLines(string lineEnding, FileResult expected)
        {
            FileResult fileResult = DecideEachFile.Perform(lineEnding);

            fileResult.Should().Be(expected);
        }
    }
}