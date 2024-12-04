using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2024AdventOfCode.Tests
{
    public class Day4Tests
    {
        [Fact]
        public void Day4ThrowsIfInputNotProvided()
        {
            //Arrange
            string input = null;

            //Act
            var exception = Assert.Throws<ArgumentNullException>( () => new Day4(input));

            //Assert
            Assert.Equal("input", exception.ParamName);
        }

        [Theory]
        [InlineData ("Day4TestInput", "The word XMAS appears 18 times.")]
        public void Day4RunFirstReturnsCorrectWordCount(string input, string expected)
        {
            //Arrange
            var sut = new Day4(input);

            //Act
            var actual = sut.RunFirst();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
