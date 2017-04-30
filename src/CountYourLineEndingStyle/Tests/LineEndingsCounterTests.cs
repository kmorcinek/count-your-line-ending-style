using System.Linq;
using CountYourLineEndingStyle.Domain;
using FluentAssertions;
using Xunit;

namespace CountYourLineEndingStyle.Tests
{
    public class LineEndingsCounterTests
    {
        [Theory]
        [InlineData(1, LineEndings.Crlf)]
        [InlineData(2, LineEndings.Crlf + "a " + LineEndings.Crlf)]
        [InlineData(3, LineEndings.Crlf + "a " + LineEndings.Crlf + LineEndings.Crlf)]
        public void Count_Crlf_line_endings(int expected, string content)
        {
            var count = LineEndingsCounter.CountCrlf(content);

            count.Should().Be(expected);
        }
    }
}