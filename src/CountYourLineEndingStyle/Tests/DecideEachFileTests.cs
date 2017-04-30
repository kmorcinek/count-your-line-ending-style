using CountYourLineEndingStyle.Domain;
using FluentAssertions;
using Xunit;

namespace CountYourLineEndingStyle.Tests
{
    public class DecideEachFileTests
    {
        [Theory]
        [InlineData("\r\n", FileResult.Crlf)]
        public void Test(string lineEnding, FileResult expected)
        {
            FileResult fileResult = DecideEachFile.Perform(lineEnding);

            fileResult.Should().Be(expected);
        }
    }
}