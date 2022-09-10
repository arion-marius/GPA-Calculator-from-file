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
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(null, null));
        }

        [Fact]
        public void GetAverage_ReturnsZero_WhenGradesIsEmpty()
        {

            List<int> grades = new List<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(grades, null));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(11)]
        public void GetAverage_ReturnsZero_WhenGradesContainsInvalidGrades(int grades)
        {

            List<int> grade = new List<int>(1) { grades };
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(grade, null));

        }

        [Theory]
        [InlineAutoData(-1)]
        [InlineAutoData(0)]
        [InlineAutoData(11)]
        public void GetAverage_ReturnsZero_WhenThesisIsInvalid(int? thesis,
            [Range(1, 10)] int grade1, [Range(1, 10)] int grade2, [Range(1, 10)] int grade3)
        {

            List<int> grades = new(3) { grade1, grade2, grade3 };
            Assert.Throws<ArgumentOutOfRangeException>(() => new Calculator(grades, thesis));

        }

        [Theory]
        [InlineData(7, 7, 7, 7)]
        [InlineData(10, 10, 6, 9)]
        [InlineData(10, 10, 7, 9.25)]
        public void GetAverage_ReturnsCorrectAverage_WhenValidData(
            int grade1, int grade2, int thesis, double average)
        {

            List<int> grades = new List<int>() { grade1, grade2 };

            var calculator = new Calculator(grades, thesis);
            var result = calculator.GetAverage();

            Assert.Equal(average, result);
        }

        [Theory]
        [InlineData(10, 7, 10, 8.875)]
        public void GetAverage_ReturnsAverage_WithMax2Decimals(
            int grade1, int grade2, int thesis, double average)
        {
            List<int> grades = new List<int>() { grade1, grade2 };

            var calculator = new Calculator(grades, thesis);
            var result = calculator.GetAverage();

            Assert.Equal(Math.Round(average, 2, MidpointRounding.AwayFromZero), result);
        }
    }
}
