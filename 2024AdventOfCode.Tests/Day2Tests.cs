using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace _2024AdventOfCode.Tests
{
    public class Day2Tests
    {
        public static IEnumerable<object[]> GetDampAscData()
        {
            yield return new object[] { new List<int> { 1, 3, 2, 4, 5 }, true };
            yield return new object[] { new List<int> { 8, 10, 4, 11, 12 }, true };
            yield return new object[] { new List<int> { 1, 2, 7, 8, 9 }, false };
        }
        public static IEnumerable<object[]> GetAscData() 
        { 
            yield return new object[] { new List<int> { 1, 2, 3 }, true }; 
            yield return new object[] { new List<int> { 6, 5, 4 }, false };
            yield return new object[] { new List<int> { 1, 3, 2 }, false };
        }

        public static IEnumerable<object[]> GetDescData()
        {
            yield return new object[] { new List<int> { 1, 2, 3 }, false };
            yield return new object[] { new List<int> { 6, 5, 4 }, true };
            yield return new object[] { new List<int> { 1, 3, 2 }, false };
        }

        public static IEnumerable<object[]> GetDeltaData()
        {
            yield return new object[] { new List<int> { 1, 2, 3 }, true };
            yield return new object[] { new List<int> { 1, 8, 9 }, false };
            yield return new object[] { new List<int> { 1, 8, 8 }, false };
        }

        [Theory]
        [MemberData(nameof(GetDampAscData))]
        public void DampenedReportsTolerateBadRecord(List<int> numbers, bool expected)
        {
            //Arrange
            var sut = new Day2("Day2TestInput.txt");

            //Act
            var actual = sut.DampenedReports(numbers);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetAscData))]
        public void ReportAscendsTrueIfNumbersIncrease(List<int> numbers, bool expected)
        {
            //Arrange
            var sut = new Day2("Day2TestInput.txt");

            //Act
            var actual = sut.ReportAscends(numbers);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetDescData))]
        public void ReportDescendsTrueIfNumbersDecrease(List<int> numbers, bool expected)
        {
            //Arrange
            var sut = new Day2("Day2TestInput.txt");

            //Act
            var actual = sut.ReportDescends(numbers);

            //Assert
            Assert.Equal(actual, expected);
        }

        [Theory]
        [MemberData(nameof(GetDeltaData))]
        public void DeltaAcceptableTrueIfNumbersDifferByThree(List<int> numbers, bool expected)
        {
            //Arrange
            var sut = new Day2("Day2TestInput.txt");

            //Act
            var actual = sut.DeltaAcceptable(numbers);

            //Assert
            Assert.Equal(actual, expected);
        }


        [Theory]
        [InlineData ("Day2TestInput.txt","Input includes 2 safe reports")]
        public void Day2ReturnsCorrectNumberSafeReports(string inputFile, string expected)
        {
            //Arrange
            var sut = new Day2 (inputFile);

            //Act
            var actual = sut.RunFirst();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData ("Day2TestInput.txt", "Thanks to the Problem Dampener, 4 reports are actually safe!")]
        public void Day2ReturnsCorrectNumberOfSafeReportsPostDampening(string inputFile, string expected)
        {
            //Arrange
            var sut = new Day2(inputFile);

            //Act
            var actual = sut.RunSecond();

            //Assert
            Assert.Equal (expected, actual);   
        }

    }
}
