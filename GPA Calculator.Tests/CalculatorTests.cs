using AutoFixture.Xunit2;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace GPA_Calculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void GetAverage_ReturnsZero_WhenGradesIsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(null, null));
        }

        [Fact]
        public void GetAverage_ReturnsZero_WhenGradesIsEmpty()
        {
            // Arrange
            //  int[] grades = Array.Empty<int>();)
            List<int> grades = new List<int>();



            // Act
            //var calculator = new Calculator(grades, null);
            //var result = calculator.GetAverage();

            // Assert
            //Assert.Equal(0, result);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(grades, null));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(11)]
        public void GetAverage_ReturnsZero_WhenGradesContainsInvalidGrades(int grades)
        {
            // Arrange
            //int[] grade = new int[] { grades };)
            List<int> grade = new List<int>(1) { grades };


            // Act
            //var calculator = new Calculator(grade, null);
            // var result = calculator.GetAverage();

            // Assert
            // Assert.Equal(0, result);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(grade, null));

        }

        [Theory]
        [InlineAutoData(-1)]
        [InlineAutoData(0)]
        [InlineAutoData(11)]
        public void GetAverage_ReturnsZero_WhenThesisIsInvalid(int? thesis,
            [Range(1, 10)] int grade1, [Range(1, 10)] int grade2, [Range(1, 10)] int grade3)
        {
            // Arrange
            // int[] grades = new int[3] { grade1, grade2, grade3 };)
            List<int> grades = new(3) { grade1, grade2, grade3 };


            // Act
            //var calculator = new Calculator(grades, thesis);
            //var result = calculator.GetAverage();

            // Assert
            // Assert.Equal(0, result);
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(grades, thesis));

        }

        [Theory]
        [InlineData(7, 7, 7, 7)]
        [InlineData(10, 10, 6, 9)]
        [InlineData(10, 10, 7, 9.25)]
        public void GetAverage_ReturnsCorrectAverage_WhenValidData(
            int grade1, int grade2, int thesis, double average)
        {
            // Arrange
            //int[] grades = new int[2] { grade1, grade2 };)
            List<int> grades = new List<int>() { grade1, grade2 };


            // Act stack vs heap
            var calculator = new Calculator(grades, thesis);
            var result = calculator.GetAverage();

            // Assert
            Assert.Equal(average, result);
        }

        [Theory]
        [InlineData(10, 7, 10, 8.875)]
        public void GetAverage_ReturnsAverage_WithMax2Decimals(
            int grade1, int grade2, int thesis, double average)
        {
            // Arrange
            // int[] grades = new int[2] { grade1, grade2 };)
            List<int> grades = new List<int>() { grade1, grade2 };


            // Act stack vs heap
            var calculator = new Calculator(grades, thesis);
            var result = calculator.GetAverage();

            // Assert
            Assert.Equal(Math.Round(average, 2, MidpointRounding.AwayFromZero), result);
        }
    }
}