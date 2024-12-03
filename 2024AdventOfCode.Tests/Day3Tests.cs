using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2024AdventOfCode.Tests
{
    public class Day3Tests
    {
        [Fact]
        public void Day3ThrowsArgExceptionIfInputNotProvided()
        {
            //Arrange
            string input = null;

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Day3(input));

            //Assert
            Assert.Equal("input", exception.ParamName);
        }

        [Theory]
        [InlineData("Day3TestInput.txt", "Result = 261.")]
        public void Day3RunFirstReturnsExpectedResult(string input, string expected)
        {
            //Arrange
            var sut = new Day3(input);

            //Act
            var actual = sut.RunFirst();
            
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
