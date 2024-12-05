using _2024AdventOfCode.Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2024AdventOfCode.Tests
{
    public class Day5Tests
    {
        [Fact]
        public void Day5ThrowsIfInputStringNotProvided()
        {
            //Arrange
            string input = null;
            
            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Day5(input));

            //Assert
            Assert.Equal("input", exception.ParamName);
        }

        [Theory]
        [InlineData ("day5TestInput.txt", "Sum of middle page numbers is 143.")]
        public void Day5RunFirstReturnsExpectedResult(string input, string expected)
        {
            //Arrange
            var sut = new Day5(input);

            //Act
            var actual = sut.RunFirst();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("day5TestInput.txt", "Sum of middle page numbers is 123.")]
        public void Day5RunSecondReturnsExpectedResult(string input, string expected)
        {
            //Arrange
            var sut = new Day5(input);

            //Act
            var actual = sut.RunSecond();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData ("5|53", "5", "53")]
        [InlineData ("81|2", "81", "2")]
        [InlineData("841|25", "841", "25")]
        [InlineData("3|222", "3", "222")]
        public void BasicOrderingRuleSplitsCorrectly(string input, string expectedFirst, string expectedSecond)
        {
            //Arrange
            var result = new BasicOrderingRule(input);

            //Act
            var actualFirst = result.EarlyValue;
            var actualSecond = result.LaterValue;

            //Assert
            Assert.Equal(expectedFirst, actualFirst);
            Assert.Equal(expectedSecond, actualSecond);

        }
    }
}
