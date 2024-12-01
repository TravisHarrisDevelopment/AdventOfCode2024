using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2024AdventOfCode.Tests
{
    public class Day1Tests
    {
        [Theory]
        [InlineData("day1TestInput.txt")]
        public void Day1ReturnsCorrectDistance(string fileName)
        {
            //Arrange
            var sut = new Day1(fileName);

            //Act
            var actual = sut.RunFirst();

            var expected = "The total distance is 11.";
            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("day1TestInput.txt")]
        public void Day1ReturnsCorrectSimilarityScore(string fileName)
        {
            //Arrange
            var sut = new Day1(fileName);

            //Act
            var actual = sut.RunSecond();

            var expected = "The similarity score is 31.";
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
