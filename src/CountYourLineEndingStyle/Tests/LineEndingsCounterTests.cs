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

        [Theory]
        [InlineData(1, LineEndings.Lf)]
        [InlineData(3, LineEndings.Lf + "a " + LineEndings.Lf + LineEndings.Lf)]
        public void Count_Lf_line_endings(int expected, string content)
        {
            var count = LineEndingsCounter.CountOnlyLf(content);

            count.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, LineEndings.Lf + "a" + LineEndings.Crlf)]
        [InlineData(2, LineEndings.Lf + "a" + LineEndings.Crlf + LineEndings.Lf)]
        public void Count_Only_Lf_when_mixed_with_Crlf(int expected, string content)
        {
            var count = LineEndingsCounter.CountOnlyLf(content);

            count.Should().Be(expected);
        }
    }
}